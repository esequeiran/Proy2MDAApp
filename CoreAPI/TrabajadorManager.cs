using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
   public class TrabajadorManager
    {
        private TrabajadorCrudFactory crudTrabajador;

        public TrabajadorManager()
        {
            crudTrabajador = new TrabajadorCrudFactory();
        }

        public void Agregar(Trabajador trabajador)
        {
            try
            {

                crudTrabajador.Create(trabajador);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //if (ex.Message.Contains("CorreoTelefono").Equals(true))
                //{
                //    ExceptionManager.GetInstance().Process(new BussinessException(6));
                //}
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        //public int RegistrarContrasenna(string cedula, string contrasenna)
        //{
        //    try
        //    {

        //        return crudOferente.RegistrarContrassena(cedula, contrasenna);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        ExceptionManager.GetInstance().Process(ex);
        //        return 0;
        //    }
        //}
        //public RespuestaCod VerificarCodigo(string cedula, string codigoVerificacion)
        //{
        //    try
        //    {

        //        return crudOferente.VerificarCodigo(cedula, codigoVerificacion);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        ExceptionManager.GetInstance().Process(ex);
        //        return new RespuestaCod();
        //    }
        //}



        public List<Trabajador> RetrieveAll(string idEmpresa)
        {
            return crudTrabajador.RetrieveTrabajadores<Trabajador>(idEmpresa);
        }
        public List<Trabajador> RetrieveAllDisponibles(string idEmpresa)
        {
            return crudTrabajador.RetrieveTrabajadoresDisponibles<Trabajador>(idEmpresa);
        }       
        public List<Trabajador> RetrieveAllAsignados(string idSolicitud)
        {
            return crudTrabajador.RetrieveTrabajadoresAsignados<Trabajador>(idSolicitud);
        }


        //public SolicitudRegistro RetriveSolicitud(string idUsuario)
        //{
        //    var list = new SolicitudRegistro();
        //    try
        //    {
        //        list = crudOferente.RetrieveSolicitud(idUsuario);

        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionManager.GetInstance().Process(ex);
        //    }
        //    return list;
        //}

        public void Update(Trabajador trabajador)
        {
            try
            {
                crudTrabajador.Update(trabajador);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }   
        public void CambioEstado(Trabajador trabajador)
        {
            try
            {
                crudTrabajador.CambioEstado(trabajador);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }       
        
        public void AsignarTrabajador(Trabajador trabajador)
        {
            try
            {
                crudTrabajador.AsignarTrabajador(trabajador);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }   
        public void EliminarTrabajador(Trabajador trabajador)
        {
            try
            {
                crudTrabajador.EliminarTrabajador(trabajador);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }



        //public void ModificarOferente(Oferente oferente)
        //{
        //    try
        //    {
        //        crudOferente.ModificarOferente(oferente);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionManager.GetInstance().Process(ex);
        //    }
        //}

        //public List<Oferente> RetrieveAllTopTenMasIngresos()
        //{
        //    return crudOferente.RetrieveAllTopTenMasIngresos<Oferente>();
        //}

    }
}
