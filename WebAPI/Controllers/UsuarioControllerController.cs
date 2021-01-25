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
    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    public class UsuarioControllerController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/UsuarioController
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new UsuarioManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET: api/UsuarioController/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UsuarioController
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UsuarioController/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UsuarioController/5
        public void Delete(int id)
        {
        }
    }
}
