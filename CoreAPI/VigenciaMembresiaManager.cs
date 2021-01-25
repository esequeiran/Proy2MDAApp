using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
namespace CoreAPI
{
    public class VigenciaMembresiaManager : BaseManager
    {
        private static readonly VigenciaMembresiaCrudFactory crud = new VigenciaMembresiaCrudFactory();
        private static readonly CancelarMembresiaCrudFactory crudCancelarMembresia = new CancelarMembresiaCrudFactory();

        /// <summary>
        /// Retorna true si tiene al menos una membresía vigente, de lo contrario retorna false.
        /// </summary>
        public static bool TieneMembresiaVigente(string idUsuario)
        {
            try
            {
                //Lista todas las membresías:
                var listaMembresias = crud.RetrieveAll<VigenciaMembresias>(idUsuario);

                var hayVigentes = false;

                if (0 < listaMembresias.Count)
                {
                    //Recorre cada membresía:
                    foreach (var membresia in listaMembresias)
                    {
                        //Busca que cada membresía esté vigente:
                        var estaVigente = crud.Retrieve<VigenciaMembresia>(new VigenciaMembresia { Valor = membresia.Id });

                        if (0 == estaVigente.Valor)
                        {
                            //Si no está vigente:

                            //Enviar correo de notificación

                            bool fueEnviado = false;

                            fueEnviado = NotificacionCorreoManager.EnviarCorreo("Vigencia de membresía", membresia.Correo, membresia.NombreCompleto, "Vigencia de membresía", "La membresía " + membresia.Valor + " ha expirado");

                            if (!fueEnviado) throw new BussinessException(0);


                            //Cancelar la membresía
                            crudCancelarMembresia.Update(new CancelarMembresia { Id = membresia.Id });

                        }
                        else
                        {
                            hayVigentes = true;
                        }
                    }
                }
                return hayVigentes;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return false;
            }
        }
    }
}
