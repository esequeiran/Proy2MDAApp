using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCorsAttribute(origins: "*" , headers: "*" , methods: "*")]
    public class TransaccionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/Transacciones")]
        public IHttpActionResult Get(string identificacion) {
            try {
                var transaccion = new Transaccion { IdUsuario = identificacion };
                apiResp = new ApiResponse();
                var mng = new TransaccionManager();
                apiResp.Data = mng.RetrieveAllTransactions(transaccion);
                return Ok(apiResp);
            } catch (BussinessException bex) {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
