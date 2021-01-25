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

    public class EspecialidadController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/Especialidad
        //[Route("")]
        //[Route("List")]

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new EspecialidadManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET: api/Especialidad/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Especialidad
        public IHttpActionResult Post(Especialidad especialidad)
        {
            try
            {
                var mng = new EspecialidadManager();
                mng.Create(especialidad);

                apiResp = new ApiResponse();
                apiResp.Message = "Sus datos han sido registrados de manera exitosa!";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        // PUT: api/Especialidad/5
        public IHttpActionResult Put(Especialidad especialidad)
        {
            try
            {
                var mng = new EspecialidadManager();
                mng.Update(especialidad);

                apiResp = new ApiResponse();
                apiResp.Message = "Información actualizada de manera exitosa!";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE: api/Especialidad/5
        public IHttpActionResult Delete(Especialidad especialidad)
        {
            try
            {
                var mng = new EspecialidadManager();
                mng.Delete(especialidad);

                apiResp = new ApiResponse();
                apiResp.Message = "Información eliminada de manera exitosa!";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
