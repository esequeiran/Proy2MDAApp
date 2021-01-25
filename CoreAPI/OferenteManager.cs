using System;
using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
   public class OferenteManager
    {

        private OferenteCrudFactory crudOferente;

        public OferenteManager()
        {
            crudOferente = new OferenteCrudFactory();
        }

        public void Agregar(Oferente oferente)
        {
            try
            {
               
                crudOferente.Create(oferente);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("CorreoTelefono").Equals(true))
                {
                    ExceptionManager.GetInstance().Process(new BussinessException(6));
                }
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public int RegistrarContrasenna(string cedula, string contrasenna)
        {
            try
            {

                return crudOferente.RegistrarContrassena(cedula, contrasenna);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionManager.GetInstance().Process(ex);
                return 0;
            }
        }
        public RespuestaCod VerificarCodigo(string cedula,string codigoVerificacion)
        {
            try
            {
               
               return crudOferente.VerificarCodigo(cedula,codigoVerificacion);

            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
                 ExceptionManager.GetInstance().Process(ex);
                return new RespuestaCod(); 
            }
        }



        public List<Oferente> RetrieveAll()
        {
            return crudOferente.RetrieveAll<Oferente>();
        }


        public SolicitudRegistro RetriveSolicitud(string idUsuario)
        {
            var list = new SolicitudRegistro();
            try
            {
                list = crudOferente.RetrieveSolicitud(idUsuario);
                
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return list;
        }

        public void Update(Oferente oferente)
        {
            try
            {
                crudOferente.Update(oferente);                           
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public void ModificarOferente(Oferente oferente)
        {
            try
            {
                crudOferente.ModificarOferente(oferente);                           
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Oferente> RetrieveAllTopTenMasIngresos() {
            return crudOferente.RetrieveAllTopTenMasIngresos<Oferente>();
        }

    }
}
