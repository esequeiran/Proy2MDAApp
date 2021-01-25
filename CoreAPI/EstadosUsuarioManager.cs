using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class EstadosUsuarioManager : BaseManager
    {
        private EstadosUsuarioCrudFactory crud;
        public EstadosUsuarioManager()
        {
            crud = new EstadosUsuarioCrudFactory();
        }

        public List<EstadosUsuario> RetrieveAll()
        {
            var c = new List<EstadosUsuario>();
            try
            {
                c = crud.RetrieveAll<EstadosUsuario>();
                if (c == null || c.Count == 0)
                {
                    throw new BussinessException(0);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }
        public List<EstadosUsuario> RetrieveAllCambio()
        {
            var c = new List<EstadosUsuario>();
            try
            {
                c = crud.RetrieveAllCambio<EstadosUsuario>();
                if (c == null || c.Count == 0)
                {
                    throw new BussinessException(0);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }


        public void CambiarEstado(EstadosUsuario obj)
        {
            try
            {
                var c = new EstadosUsuario();
                c = crud.Retrieve<EstadosUsuario>(obj);
                if (c == null)
                {
                    throw new BussinessException(0);
                }
                var mensaje = "";

                //Mensaje según el id del estado:
                switch (obj.Id)
                {
                    case 2: //2	Bloqueado
                        mensaje = "Esta cuenta ha sido bloqueada por un administrador.";
                        break;
                    case 3: //3	Baneado
                        mensaje = "Esta cuenta ha sido eliminada permanentemente.";
                        break;
                    case 4: //4	Inactivo
                        mensaje = "Esta cuenta ha sido inactivada. No podrá usar el sistema hasta que un administrador del sistema la active de nuevo.";
                        break;
                    case 5: //5	Activo (queda con estado 11: Pendiente cambio de contraseña)
                        mensaje = "Esta cuenta ha sido activada. Para hacer uso del sistema debe <a href=\"http://localhost:61102/Home/vRecuperarContrasenna\" target=\"_blank\">restablecer su contraseña</a>.";
                        break;
                    case 13: //13 Suspendido
                        mensaje = "Esta cuenta estará suspendida por " + obj.diasSuspendido + " día(s).";
                        break;
                }

                if (mensaje.Length == 0) throw new BussinessException(3);

                bool fueEnviado = false;

                fueEnviado = NotificacionCorreoManager.EnviarCorreo("Cambio de estado de la cuenta de usuario", obj.Valor, c.Valor, "Cambio de estado de la cuenta de usuario", mensaje);

                if (!fueEnviado) throw new BussinessException(3);

                crud.Update(obj);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


    }
}
