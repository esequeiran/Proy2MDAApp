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
    public class NotificacionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/Notificacion")]
        public IHttpActionResult Post(Notificacion notificacion) {
            var mng = new HorasTrabajadasManager();
            apiResp = new ApiResponse();

            try {
                mng.CreateNotificacion(notificacion);
                apiResp.Message = "Se ha registrado correctamente";
                return Ok(apiResp);
            } catch (BussinessException bex) {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        [Route("api/Notificacion")]
        public IHttpActionResult Get(string IdCliente) {
            var notificacion = new Notificacion { IdCliente = IdCliente };
            apiResp = new ApiResponse(); 
            var mng = new NotificacionManager();

            apiResp.Data = mng.RetrieveById(notificacion);

            return Ok(apiResp);
        }


        [HttpGet]
        [Route("api/Notificaciones")] //TRAE TODAS
        public IHttpActionResult GetNotificaciones(string IdCliente) {
            var notificacion = new Notificacion { IdCliente = IdCliente };
            apiResp = new ApiResponse();
            var mng = new NotificacionManager();

            apiResp.Data = mng.RetrieveAll(notificacion);

            return Ok(apiResp);
        }

        [Route("api/Notificacion")]
        public IHttpActionResult Put(Notificacion notificacion) {
            try {
                var mng = new NotificacionManager();
                mng.Update(notificacion);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha actualizado correctamente";
                return Ok(apiResp);
            } catch (BussinessException bex) {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }

        [HttpPost]
        [Route("api/PagoSolicitud")]
        public IHttpActionResult PagoSolicitud(Notificacion notificacion) {
            try {
                var mng = new NotificacionManager();
                mng.UpdatePagoSolicitud(notificacion);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha realizado el pago éxitosamente correctamente";
                return Ok(apiResp);
            } catch (BussinessException bex) {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }
    }
}
