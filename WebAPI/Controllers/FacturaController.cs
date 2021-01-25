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
    public class FacturaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/Factura")]
        public IHttpActionResult Get(int idSolicitud) {
            var fac = new Factura { IdSolicitud = idSolicitud};
            apiResp = new ApiResponse();
            var mng = new FacturaManager();

            apiResp.Data = mng.RetrieveById(fac);

            return Ok(apiResp);
        }

        [HttpGet]
        [Route("api/Detalle")] //TRAE TODAS
        public IHttpActionResult GetFacDetalle(int idSolicitud) {
            var fac = new Factura { IdSolicitud = idSolicitud };
            apiResp = new ApiResponse();
            var mng = new FacturaManager();

            apiResp.Data = mng.RetrieveAllFacDetalle(fac);

            return Ok(apiResp);
        }
    }
}
