using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //VERSION NUEVA
    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    public class TipoDeTrabajoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET: api/TipoDeTrabajo
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new TipoDeTrabajoManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET: api/TipoDeTrabajo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TipoDeTrabajo
        public IHttpActionResult Post(TipoDeTrabajo tipoDeTrabajo)
        {
            try
            {
                var mng = new TipoDeTrabajoManager();
                mng.Create(tipoDeTrabajo);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        // PUT: api/TipoDeTrabajo/5
        public IHttpActionResult Put(TipoDeTrabajo tipoDeTrabajo)
        {
            try
            {
                var mng = new TipoDeTrabajoManager();
                mng.Update(tipoDeTrabajo);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE: api/TipoDeTrabajo/5
        public IHttpActionResult Delete(TipoDeTrabajo tipoDeTrabajo)
        {
            try
            {
                var mng = new TipoDeTrabajoManager();
                mng.Delete(tipoDeTrabajo);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
