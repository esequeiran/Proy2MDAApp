using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CoreAPI;
using Exceptions;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    public class MonederoController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        [Route("api/RecargarMonedero")]
        public IHttpActionResult Put(string cedula,double monto)
        {
            try
            {
                var mng = new  MonederoManager();
                mng.RecargarMonedero(cedula,monto);
                apiResp = new ApiResponse();
                apiResp.Message = "La recarga fue exitosa!.";
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }      
        
        [Route("api/RetiroMonedero")]
        public IHttpActionResult PutRetiro(string cedula,double monto)
        {
            try
            {
                var mng = new MonederoManager();
                mng.RetiroMonedero(cedula,monto);
                apiResp = new ApiResponse();
                apiResp.Message = "El retiruo fue exitoso!.";
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }


        public IHttpActionResult Get(string cedula)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new MonederoManager();

                apiResp.Data = mng.RetriveSaldo(cedula);
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}