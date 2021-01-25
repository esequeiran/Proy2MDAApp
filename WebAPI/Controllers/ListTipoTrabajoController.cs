using CoreAPI;
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
    //VERSION NUEVA PARA LISTAR LAS ESPECIALIDADES CON UN DROPDOWN
    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    //[RoutePrefix("api/List")]
    [ExceptionFilter]
    public class ListTipoTrabajoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET: api/List/Especialidad
        //[Route("Especialidad")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new ListTipoTrabajoManager();
            apiResp.Data = mng.RetrieveAll();

            //return Ok(apiResp);
            return Ok(apiResp.Data);

        }
    }
}
