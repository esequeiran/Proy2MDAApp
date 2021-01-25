using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CoreAPI;
using Entities_POJO;
using Exceptions;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OferenteJuridicoController : ApiController
    {
        ApiResponse cons = new ApiResponse();

        //api/oferenteFisico
        public IHttpActionResult Post(OferenteJuridico juridico)
        {
            try
            {
                var mng = new OferenteJuridicoManager();
                mng.Agregar(juridico);

                cons = new ApiResponse();
                cons.Message = "Accion executada!";

                return Ok(cons.Message);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                      + bex.AppMessage.Message));

            }
        }

    }
}
