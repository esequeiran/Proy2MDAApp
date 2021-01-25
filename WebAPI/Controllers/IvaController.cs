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
    public class IvaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new IvaManager();
            apiResp.Data = mng.Retrieve();

            return Ok(apiResp);
        }

        [HttpPut]
        // PUT
        // UPDATE
        public IHttpActionResult Put(Iva iva)
        {
            try
            {
                var mng = new IvaManager();
                mng.Update(iva);

                apiResp = new ApiResponse();
                apiResp.Message = "Se ha modificado con éxito";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}