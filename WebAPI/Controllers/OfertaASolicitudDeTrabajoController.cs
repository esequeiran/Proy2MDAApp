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
    public class OfertaASolicitudDeTrabajoController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();
        // GET: api/OfertaASolicitudDeTrabajo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OfertaASolicitudDeTrabajo/5
        public IHttpActionResult Get(int idSolicitudOferta)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new OfertaASolicitudDeTrabajoManager();
                var ofer = new OfertaASolicitudDeTrabajo {
                    IdSolicitud = idSolicitudOferta
                };                
                apiResp.Data = mng.RetrieveOfertasPorSolicitudParaAceptar(ofer);
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        // POST: api/OfertaASolicitudDeTrabajo
        public IHttpActionResult Post(OfertaASolicitudDeTrabajo oferta)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new OfertaASolicitudDeTrabajoManager();
                mng.Create(oferta);                            
                apiResp.Message = "Registro de oferta exitoso";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }

        }

        [Route("api/AceptarOfertaASolicitud")]
        public IHttpActionResult PostAceptar(OfertaASolicitudDeTrabajo oferta)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudDeTrabajoManager();               
              
                mng.UpdateCreateOfertaTrabajo(oferta);                
                apiResp.Message = "Orden de trabajo generada de manera exitosa";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }

        }

        // PUT: api/OfertaASolicitudDeTrabajo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OfertaASolicitudDeTrabajo/5
        public void Delete(int id)
        {
        }
    }
}
