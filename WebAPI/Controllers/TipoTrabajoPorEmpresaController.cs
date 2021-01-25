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
    //[RoutePrefix("api/TipoTrabajoPorEmpresa")]

    public class TipoTrabajoPorEmpresaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/TipoTrabajoPorEmpresa
        //[Route("")]
        //[Route("List")]

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new TipoTrabajoPorEmpresaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        //Fixed
        [HttpGet]
        public IHttpActionResult Get(string idUsuario)
        {
            apiResp = new ApiResponse();
            var mng = new TipoTrabajoPorEmpresaManager();
            var obj = new TipoTrabajoPorEmpresa { Cedula_Usuario = idUsuario };
            apiResp.Data = mng.RetrieveAll2(obj);

            return Ok(apiResp);
        }

        // POST: api/TipoTrabajoPorEmpresa
        public IHttpActionResult Post(TipoTrabajoPorEmpresa tipoTrabajoPorEmpresa)
        {
            try
            {
                var mng = new TipoTrabajoPorEmpresaManager();
                mng.Create(tipoTrabajoPorEmpresa);

                apiResp = new ApiResponse();
                apiResp.Message = "Sus datos han sido registrados de manera exitosa!";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                Console.WriteLine(bex.Data);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                      + bex.AppMessage.Message));
            }
        }

        // PUT: api/TipoTrabajoPorEmpresa/5
        public IHttpActionResult Put(TipoTrabajoPorEmpresa tipoTrabajoPorEmpresa)
        {
            try
            {
                var mng = new TipoTrabajoPorEmpresaManager();
                mng.Update(tipoTrabajoPorEmpresa);

                apiResp = new ApiResponse();
                apiResp.Message = "Información actualizada de manera exitosa!";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE: api/TipoTrabajoPorEmpresa/5

        public IHttpActionResult Delete(TipoTrabajoPorEmpresa tipoTrabajoPorEmpresa)
        {
            try
            {
                var mng = new TipoTrabajoPorEmpresaManager();
                mng.Delete(tipoTrabajoPorEmpresa);

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
