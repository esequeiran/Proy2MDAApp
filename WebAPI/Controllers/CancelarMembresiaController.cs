using CoreAPI;
using Entities_POJO;
using Exceptions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CancelarMembresiaController : ApiController
    {
        private ApiResponse apiResp = new ApiResponse();

        [HttpGet]
        [Route("api/CancelarMembresia/{id:int}")]
        public IHttpActionResult CancelarMembresia([FromUri] int id)
        {
            try
            {
                var mng = new CancelarMembresiaManager();
                var obj = new CancelarMembresia { Id = id};

                mng.CancelarMembresia(obj);

                apiResp = new ApiResponse();
                apiResp.Message = "La membresía se ha cancelado con éxito";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(bex.AppMessage.Message, System.Text.Encoding.UTF8, "text/plain");
                response.RequestMessage = Request;
                return new ResponseMessageResult(response);
            }
        }
    }
}