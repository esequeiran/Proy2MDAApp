using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCorsAttribute(origins: "*" , headers: "*" , methods: "*")]
    public class HorasTrabajadasController:ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get(string idtipo) {
            int idTp = Int32.Parse(idtipo);
            var tipos = new SolicitudDeTrabajo { IdSolicitud = idTp };
            apiResp = new ApiResponse();
            var mng = new HorasTrabajadasManager();

            apiResp.Data = mng.RetrieveAllTiposTrabajo(tipos);

            return Ok(apiResp);
        }

        public IHttpActionResult Post(SolicitudDeTrabajo solicitud) {
            var mng = new HorasTrabajadasManager();
            apiResp = new ApiResponse();
            
            try {
                mng.Create(solicitud);
                apiResp.Message = "Se ha registrado correctamente";
                return Ok(apiResp);
            } catch (BussinessException bex) {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }


        
        [Route("api/NotificacionCreate")]
        public IHttpActionResult Post(Notificacion notificacion) {
            try {
                var mng = new HorasTrabajadasManager();
                mng.CreateNotificacion(notificacion);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha actualizado correctamente";
                return Ok(apiResp);
            } catch (BussinessException bex) {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }
    }
}
