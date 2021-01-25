using CoreAPI;
using Entities_POJO;
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


    public class ListController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET: api/List/Especialidad
        //[Route("Especialidad")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new ListManager();
            apiResp.Data = mng.RetrieveAll();

            //return Ok(apiResp);
            return Ok(apiResp.Data);

        }

        [Route("api/List/TiposTrabajo")]
        public IHttpActionResult GetTiposTrabajo()
        {
            apiResp = new ApiResponse();
            var mng = new ListManager();
            apiResp.Data = mng.RetrieveAllTipoTrabajo();

            //return Ok(apiResp);
            return Ok(apiResp.Data);

        }

        [Route("api/List/Localizaciones")]
        public IHttpActionResult GetLocalizciones(string identificacion)
        {
            apiResp = new ApiResponse();
            var localizacion = new Localizacion { IdUsuario = identificacion };
            var mng = new ListManager();
            apiResp.Data = mng.RetrieveAllLocalizacionesCliente(localizacion);

            //return Ok(apiResp);
            return Ok(apiResp.Data);

        }

    }
}
