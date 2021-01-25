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
    public class IngresosAppController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/Ingresos")]
        public IHttpActionResult Get(string identificacion) {
            try {
                var transaccion = new Transaccion { IdUsuario = identificacion };
                apiResp = new ApiResponse();
                var mng = new TransaccionManager();
                apiResp.Data = mng.RetrieveAllIngresosApp(transaccion);
                return Ok(apiResp);
            } 
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }       
        
        [Route("api/IngresosOferente")]
        public IHttpActionResult GetOferente(string cedula) {
            try {
                var transaccion = new Transaccion { IdUsuario = cedula };
                apiResp = new ApiResponse();
                var mng = new TransaccionManager();
                apiResp.Data = mng.RetrieveAllIngresosOferente(transaccion);
                return Ok(apiResp);
            } 
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
