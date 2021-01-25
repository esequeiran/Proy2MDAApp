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
    public class LocalizacionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/localizacion
        // Retrieve
        public IHttpActionResult Get(string identificacion)
        {
            var localizacion = new Localizacion { IdUsuario = identificacion };
            apiResp = new ApiResponse();
            var mng = new LocalizacionManager();
            apiResp.Data = mng.RetrieveAll(localizacion);

            return Ok(apiResp);
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Localizacion localizacion)
        {

            try
            {
                var mng = new LocalizacionManager();
                mng.Create(localizacion);

                apiResp = new ApiResponse();
                apiResp.Message = "Se ha registrado con éxito";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Localizacion localizacion)
        {
            try
            {
                var mng = new LocalizacionManager();
                mng.Update(localizacion);

                apiResp = new ApiResponse();
                apiResp.Message = "Se ha modificado con éxito";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE 
        public IHttpActionResult Delete(Localizacion localizacion)
        {
            try
            {
                var mng = new LocalizacionManager();
                mng.Delete(localizacion);

                apiResp = new ApiResponse();
                apiResp.Message = "Se ha eliminado con éxito";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}