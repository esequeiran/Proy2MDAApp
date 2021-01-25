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
    //[RoutePrefix("api/EstadosUsuario")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EstadosUsuarioController : ApiController
    {
        private ApiResponse apiResp = new ApiResponse();

        [Route("api/EstadosUsuario")]
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new EstadosUsuarioManager();
                apiResp.Data = mng.RetrieveAll();
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

        [HttpGet]
        [Route("api/EstadosUsuarioCambio")]
        public IHttpActionResult EstadosUsuarioCambio()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new EstadosUsuarioManager();
                apiResp.Data = mng.RetrieveAllCambio();
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

        [HttpGet]
        [Route("api/EstadosUsuario/{correo}/{idNuevoEstado:int}/{diasSuspendido:int}")]
        public IHttpActionResult CambiarEstado([FromUri] string correo, int idNuevoEstado, int diasSuspendido)
        {
            try
            {
                var mng = new EstadosUsuarioManager();
                var obj = new EstadosUsuario { Valor = correo, Id = idNuevoEstado, diasSuspendido = diasSuspendido };

                mng.CambiarEstado(obj);

                apiResp = new ApiResponse();
                apiResp.Message = "El estado se ha modificado con éxito";

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
