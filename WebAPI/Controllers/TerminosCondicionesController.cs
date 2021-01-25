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
    //[RoutePrefix("api/Especialidad")]

    public class TerminosCondicionesController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/Especialidad
        //[Route("")]
        //[Route("List")]

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new TerminosCondicionesManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET: api/Especialidad/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Especialidad
        public IHttpActionResult Post(TerminosCondiciones terminos)
        {
            try
            {
                var mng = new TerminosCondicionesManager();
                mng.Create(terminos);

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

        // PUT: api/Especialidad/5
        public IHttpActionResult Put(TerminosCondiciones terminos)
        {
            try
            {
                var mng = new TerminosCondicionesManager();
                mng.Update(terminos);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE: api/Especialidad/5
        public IHttpActionResult Delete(TerminosCondiciones terminos)
        {
            try
            {
                var mng = new TerminosCondicionesManager();
                mng.Delete(terminos);

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
