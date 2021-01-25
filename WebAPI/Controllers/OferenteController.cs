using System;
using System.Web.Http;
using System.Web.Http.Cors;
using CoreAPI;
using Entities_POJO;
using Exceptions;
using WebAPI.Models;

using BotDetect.Web;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OferenteController : ApiController
    {
        ApiResponse cons = new ApiResponse();

        //api/oferenteFisico
        public IHttpActionResult Post(Oferente oferente)
        {

            string userEnteredCaptchaCode = oferente.UserEnteredCaptchaCode;
            string captchaId = oferente.CaptchaId;

            if (!IsCaptchaCorrect(userEnteredCaptchaCode, captchaId))
            {
                return InternalServerError(new Exception("Un dato es incorrecto"));
            }

            try
            {
                var mng = new OferenteManager();
                mng.Agregar(oferente);

                cons = new ApiResponse();
                cons.Message = "Sus datos han sido registrados de manera exitosa!";

                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                Console.WriteLine(bex.Data);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                      + bex.AppMessage.Message));

            }
        }


        [Route("api/VerificarCodigo")]
        public IHttpActionResult Get(string cedula, string codigoVerificacion)
        {
            try
            {
                var mng = new OferenteManager();
                

                cons = new ApiResponse();
                cons.Data = mng.VerificarCodigo(cedula,codigoVerificacion);

                return Ok(cons.Data);

            }
            catch (BussinessException bex)
            {
                Console.WriteLine(bex.Data);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                      + bex.AppMessage.Message));

            }
        }

        [Route("api/RegistrarContrasenna")]
        public IHttpActionResult Post(string Cedula, string Contrasenna)
        {
            try
            {
                var mng = new OferenteManager();
                cons = new ApiResponse();

                var respuesta = mng.RegistrarContrasenna(Cedula, Contrasenna);
                if (respuesta == -1)
                {
                    cons.Message = "El registro ha sido exitoso!";
                    return Ok(cons.Message);
                }

                var errorMessage = ExceptionManager.GetInstance().GetMessage(new BussinessException(respuesta)).Message;
                return InternalServerError(new Exception(errorMessage));
            }
            catch (BussinessException bex)
            {
                Console.WriteLine(bex.Data);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                      + bex.AppMessage.Message));

            }
        }
        // the captcha validation function
        private bool IsCaptchaCorrect(string userEnteredCC, string captId)
        {
            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha captcha = new SimpleCaptcha();
            // execute the captcha validation
            return captcha.Validate(userEnteredCC, captId);
        }

        //api/oferente

        public IHttpActionResult Get()
        {
            cons = new ApiResponse();
            var mng = new OferenteManager();
            cons.Data = mng.RetrieveAll();

            return Ok(cons);
        }

        //api/oferente

        public IHttpActionResult Get(string idUsuario)
        {
            try
            {
                cons = new ApiResponse();
                var mng = new OferenteManager();

                cons.Data = mng.RetriveSolicitud(idUsuario);
                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Oferente oferente)
        {
            try
            {
                var mng = new OferenteManager();
                mng.Update(oferente);
                cons = new ApiResponse();
                cons.Message = "Estado actualizado";
                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }

        [Route("api/ModificarPerfilOferente")]
        public IHttpActionResult PutOferente(Oferente oferente)
        {
            try
            {
                var mng = new OferenteManager();
                mng.ModificarOferente(oferente);
                cons = new ApiResponse();
                cons.Message = "Información Actualizada!";
                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }


        [Route("api/EnviarCorreo")]
        public IHttpActionResult PostEnviarCorreo(CorreoEstructura dato)
        {
            
            try
            {
                cons = new ApiResponse();
                var mng = new EnviarCorreoManager();

                dato.PlantillaContenidoHtml = "<!DOCTYPE html>" +
                    "<html LANG=" + "ES" + ">" +
                        "<head>" +
                            "<link href=" + "https://fonts.googleapis.com/css?family=Roboto" + " rel=" + "stylesheet" + ">" +
                            "<style>" +
                                "h1{" +
                                    "display: inline-block;" +
                                    "font-size: 40px;" +
                                    "text-align: left;" +
                                    "margin-left: 50px;" +
                                    "color: #f9aa33;" +
                                    "}" +
                                    "h2{" +
                                        "text-align: center;" +
                                        "font-size: 30px;" +
                                        "margin-bottom: 50px;" +
                                        "color: #232f34;" +
                                        "}" +
                                        ".wrapper{" +
                                            "background : #81ecec;" +
                                            "font-family: 'Roboto', sans-serif;" +
                                            "}" +
                                            ".container{" +
                                                "display: block;" +
                                                "margin: 0 auto;" +
                                                "background: #fff;" +
                                                "width: 80%;" +
                                                "text-align: center;" +
                                                "padding: 10px;" +
                                                "}" +
                                                ".pdfContainer{" +
                                                    "display: block;" +
                                                    "margin: 0 auto;" +
                                                    "background: #fff;" +
                                                    "width: 100%;" +
                                                    "text-align: center;" +
                                                    "padding: 10px;" +
                                                    "height: 80%;" +
                                                    "}" +
                                                    ".btnContainer{" +
                                                        "display: block;" +
                                                        "margin: 0 auto;" +
                                                        "background: #fff;" +
                                                        "width: 100%;" +
                                                        "text-align: center;" +
                                                        "padding: 10px;" +
                                                        "height: 5%;" +
                                                        "}" +
                                                        "a{" +
                                                            "text-align: right;" +
                                                            "text-decoration: none;" +
                                                            "padding: 10px;" +
                                                            "background: #f9aa33;" +
                                                            "color: #344955;" +
                                                            "font-size: 22px;" +
                                                            "display: inline-block;" +
                                                            "margin-left: 10px;" +
                                                            "}" +

                                                            " a:hover{" +
                                                                "background: #ffbe76;" +
                                                                "cursor: pointer;" +
                                                                "transition: all 300ms ease;" +
                                                                "}" +
                                                            "p{" +
                                                                "font-size: 22px;" +
                                                                "color: #344955;" +
                                                                "text-align: left;" +
                                                                " }" +
                                                                " span{" +
                                                                    "  color: #344955;" +
                                                                    "  }" +
                                                                    "  iframe{" +
                                                                        "   display: block;" +
                                                                        "    width : 40%;" +
                                                                        "    height :80%;" +
                                                                        " }" +
                                                                        " </style>" +
                                                               " </head>" +
                                                               " <body>" +
                        " <div class=" + "container" + ">" +
                            " <h1>Solicitud de registro</h1>" +
                            "<h2><i>Estimado(a) usuario " + "</i></h2>" +
                            " <p>Reciba un cordial saludo. Su solicitud de registro a la plataforma MDA ha sido rechazada.</p>" +
                            "  <div class=" + "pdfContainer" + ">" +
                                            " </div>" +
                                " <div class=" + "btnContainer" + ">" +
                                    " </div>   " +
                                " </div>      " +
                                    " </body> " +
                                    " </html> ";


                mng.ejecutarCorreo(dato);
                cons.Message = "Correo enviado correctamente.";
                return Ok(cons);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }



    }
}
