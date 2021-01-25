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
    public class DocumentoController : ApiController
    {
        ApiResponse cons = new ApiResponse();

        //api/oferenteFisico
        public IHttpActionResult Post(Documento documento)
        {
            try
            {
                var mng = new DocumentoManager();
                mng.Agregar(documento);

                cons = new ApiResponse();
                cons.Message = "Accion executada!";

                return Ok(cons.Message);

            }
            catch (BussinessException bex)
            {
                Console.WriteLine(bex.Data);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                      + bex.AppMessage.Message));

            }
        }
    }
}
