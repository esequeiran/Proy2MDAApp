using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CoreAPI;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class DashOferenteController : ApiController
    {
        ApiResponse cons = new ApiResponse();

        [Route("api/TrabajosRealizados")]

        public IHttpActionResult Get(string idEmpresa)
        {
            cons = new ApiResponse();
            var mng = new DashOferenteManager();
            cons.Data = mng.RetrieveAllTrabajos(idEmpresa);

            return Ok(cons);
        }     
        [Route("api/TrabajadoresOferente")]

        public IHttpActionResult GetTrabajadores(string idEmpresa)
        {
            cons = new ApiResponse();
            var mng = new DashOferenteManager();
            cons.Data = mng.RetrieveAllTrabajadores(idEmpresa);

            return Ok(cons);
        }

    }
}
