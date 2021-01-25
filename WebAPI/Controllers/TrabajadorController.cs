using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BotDetect.Web;
using CoreAPI;
using Entities_POJO;
using Exceptions;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TrabajadorController : ApiController
    {
        ApiResponse cons = new ApiResponse();

        //api/Trabajador
        public IHttpActionResult Post(Trabajador trabajador)
        {

            string userEnteredCaptchaCode = trabajador.UserEnteredCaptchaCode;
            string captchaId = trabajador.CaptchaId;

            if (!IsCaptchaCorrect(userEnteredCaptchaCode, captchaId))
            {
                return InternalServerError(new Exception("Un dato es incorrecto"));
            }

            try
            {
                var mng = new TrabajadorManager();
                mng.Agregar(trabajador);

                cons = new ApiResponse();
                cons.Message = "Los datos han sido registrados de manera exitosa!";

                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                Console.WriteLine(bex.Data);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                      + bex.AppMessage.Message));

            }
        }

        //// the captcha validation function
        private bool IsCaptchaCorrect(string userEnteredCC, string captId)
        {
            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha captcha = new SimpleCaptcha();
            // execute the captcha validation
            return captcha.Validate(userEnteredCC, captId);
        }

        //api/Trabajador

        public IHttpActionResult Get(string idEmpresa)
        {
            cons = new ApiResponse();
            var mng = new TrabajadorManager();
            cons.Data = mng.RetrieveAll(idEmpresa);

            return Ok(cons);
        }

        [Route("api/TrabajadoresDisponibles")]

        public IHttpActionResult GetTra(string idEmpresa)
        {
            cons = new ApiResponse();
            var mng = new TrabajadorManager();
            cons.Data = mng.RetrieveAllDisponibles(idEmpresa);

            return Ok(cons);
        }
        
        [Route("api/TrabajadoresAsignados")]

        public IHttpActionResult GetTrabajadoresAsignados(string idSolicitud)
        {
            cons = new ApiResponse();
            var mng = new TrabajadorManager();
            cons.Data = mng.RetrieveAllAsignados(idSolicitud);

            return Ok(cons);
        }


        public IHttpActionResult Put(Trabajador trabajador)
        {
            try
            {
                var mng = new TrabajadorManager();
                mng.Update(trabajador);
                cons = new ApiResponse();
                cons.Message = "Información actualizada!";
                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }
        [Route("api/CambioEstado")]

        public IHttpActionResult PutCambioEstado(Trabajador trabajador)
        {
            try
            {
                var mng = new TrabajadorManager();
                mng.CambioEstado(trabajador);
                cons = new ApiResponse();
                cons.Message = "Estado actualizado!";
                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }

        [Route("api/AsignarTrabajador")]

        public IHttpActionResult PostAsignarTrabajador(Trabajador trabajador)
        {
            try
            {
                var mng = new TrabajadorManager();
                mng.AsignarTrabajador(trabajador);
                cons = new ApiResponse();
                cons.Message = "Trabajador Asignado!";
                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }

        [Route("api/Eliminar")]

        public IHttpActionResult DeleteTrabajadorAsignado(Trabajador trabajador)
        {
            try
            {
                var mng = new TrabajadorManager();
                mng.EliminarTrabajador(trabajador);
                cons = new ApiResponse();
                cons.Message = "Trabajador eliminado del trabajo!";
                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }

    }
}
