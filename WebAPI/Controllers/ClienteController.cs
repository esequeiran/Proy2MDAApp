using BotDetect.Web;
using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCorsAttribute(origins: "*" , headers: "*" , methods: "*")]
    public class ClienteController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET: api/Cliente
        public IHttpActionResult Get() {
            apiResp = new ApiResponse();
            var mng = new ClienteManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }


        public IHttpActionResult Get(string identificacion) {
            var cliente = new Cliente { Identificacion = identificacion };
            apiResp = new ApiResponse();
            var mng = new ClienteManager();

            apiResp.Data = mng.RetrieveById(cliente);

            return Ok(apiResp);
        }

        // POST: api/Cliente
        public IHttpActionResult Post(Cliente cliente) {

            string userEnteredCaptchaCode = cliente.UserEnteredCaptchaCode;
            string captchaId = cliente.CaptchaId;

            if (!IsCaptchaCorrect(userEnteredCaptchaCode , captchaId)) {
                return InternalServerError(new Exception("Código captcha inválido. Intente de nuevo"));
            }

            var mng = new ClienteManager();
            apiResp = new ApiResponse();
            try {
                if (String.IsNullOrEmpty(cliente.ApellidoDos)) {
                    cliente.ApellidoDos = " ";

                    mng.Create(cliente);
                    var mngCorreoSms = new DatosCorreoSmsManager();
                    var pdato = new DatosAuxiliaresSmsCorreo {
                        Cedula = cliente.Identificacion
                    };
                    mngCorreoSms.RetrieveCorreoSMSPrimerAccesoPlataforma(pdato);

                    apiResp.Message = "Se ha registrado correctamente";
                    return Ok(apiResp);
                } else {
                    mng.Create(cliente);
                    var mngCorreoSms = new DatosCorreoSmsManager();
                    var pdato = new DatosAuxiliaresSmsCorreo {
                        Cedula = cliente.Identificacion
                    };
                    mngCorreoSms.RetrieveCorreoSMSPrimerAccesoPlataforma(pdato);
                    apiResp.Message = "Se ha registrado correctamente";
                    return Ok(apiResp);
                }
            } catch (BussinessException bex) {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // the captcha validation function
        private bool IsCaptchaCorrect(string userEnteredCC , string captId) {
            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha captcha = new SimpleCaptcha();
            // execute the captcha validation
            return captcha.Validate(userEnteredCC , captId);
        }

        // PUT: api/Cliente
        public IHttpActionResult Put(Cliente cliente) {
            try {
                var mng = new ClienteManager();
                mng.Update(cliente);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha actualizado correctamente";
                return Ok(apiResp);
            } catch (BussinessException bex) {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }
    }
}
