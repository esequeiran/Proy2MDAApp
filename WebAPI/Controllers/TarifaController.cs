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

    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    public class TarifaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/Tarifa
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new TarifaManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }

        // GET: api/Tarifa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tarifa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tarifa/5
        public IHttpActionResult Put(Tarifa ptarifa)
        {
            try
            {
                var mng = new TarifaManager();
                mng.Update(ptarifa);

                apiResp = new ApiResponse();
                apiResp.Message = "Tarifa actualizada correctamente";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        // DELETE: api/Tarifa/5
        public void Delete(int id)
        {
        }
    }
}
