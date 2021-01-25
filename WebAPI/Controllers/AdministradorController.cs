using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    public class AdministradorController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/Administrador
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new AdministradorManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }


        public IHttpActionResult Get(string identificacion)
        {
            var admin = new Administrador { Identificacion = identificacion };
            apiResp = new ApiResponse();
            var mng = new AdministradorManager();

            apiResp.Data = mng.RetrieveById(admin);

            return Ok(apiResp);
        }

        // POST: api/Administrador
        public IHttpActionResult Post(Administrador administrador)
        {
            var mng = new AdministradorManager();
            apiResp = new ApiResponse();
            var edad = 2020 - administrador.FechaNacimiento.Year;

            try
            {
                if (edad >= 18) {
                    if (String.IsNullOrEmpty(administrador.ApellidoDos)) {
                        administrador.ApellidoDos = " ";

                        mng.Create(administrador);
                        var mngCorreoSms = new DatosCorreoSmsManager();
                        var pdato = new DatosAuxiliaresSmsCorreo {
                            Cedula = administrador.Identificacion
                        };
                        mngCorreoSms.RetrieveCorreoSMSPrimerAccesoPlataforma(pdato);

                        apiResp.Message = "Se ha registrado correctamente";
                        return Ok(apiResp);
                    } else {
                        mng.Create(administrador);
                        var mngCorreoSms = new DatosCorreoSmsManager();
                        var pdato = new DatosAuxiliaresSmsCorreo {
                            Cedula = administrador.Identificacion
                        };
                        mngCorreoSms.RetrieveCorreoSMSPrimerAccesoPlataforma(pdato);
                        apiResp.Message = "Se ha registrado correctamente";
                        return Ok(apiResp);
                    }
                } else {
                    throw new BussinessException(17);
                }
                    
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // PUT: api/Administrador
        public IHttpActionResult Put(Administrador administrador)
        {
            try
            {
                var mng = new AdministradorManager();
                mng.Update(administrador);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha actualizado correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }

        // DELETE: api/Administrador
        public IHttpActionResult Delete(Administrador administrador)
        {
            try
            {
                var mng = new AdministradorManager();
                mng.Delete(administrador);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha eliminado correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}