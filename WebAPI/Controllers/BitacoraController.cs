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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BitacoraController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/Bitacora
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new BitacoraManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }

        // GET: api/Bitacora/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bitacora
        public IHttpActionResult Post(String CedulaUsuario, String DescripcionAccion)
        {
            try
            {
                var mng = new BitacoraManager();
                var bit = new Bitacora
                {
                    CedulaUsuario = CedulaUsuario,
                    DescripcionAccion = DescripcionAccion
                };
                mng.Create(bit);
                apiResp = new ApiResponse();
                apiResp.Message = "Registro de bitácora correcto";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }

        }

        // PUT: api/Bitacora/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bitacora/5
        public void Delete(int id)
        {
        }
    }
}
