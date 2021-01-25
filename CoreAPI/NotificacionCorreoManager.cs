using Entities_POJO;
using Exceptions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class NotificacionCorreoManager
    {
        //"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";
        private const string API_KEY = "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";

        /// <summary>
        /// Retorna true si el correo fué aceptado (Si el correo fué aceptado no garantiza que el correo llegó a su destino), de lo contrario retorna false.
        /// </summary>
        public static bool EnviarCorreo(string asunto, string correo, string nombreUsuario, string tituloMensaje, string mensaje)
        {
            try
            {
                var estructura = GetCorreoEstructura(asunto, correo, nombreUsuario, tituloMensaje, mensaje);

                var client = new SendGridClient(API_KEY);
                var from = new EmailAddress("aureo.soft4@gmail.com", "Aureosoft-MDA");
                var to = new EmailAddress(estructura.correoDestinatario, estructura.nombreDestinatario);
                var msg = MailHelper.CreateSingleEmail(from, to, estructura.Asunto, estructura.ContenidoTextoPlano, estructura.PlantillaContenidoHtml);
                client.Version = "v3";
                var response =
                    Task.Run(() => client.SendEmailAsync(msg));
                response.Wait();
                var result = response.Result;

                /*
                 Console.WriteLine(result.StatusCode);
                 Console.WriteLine(result.Body.ReadAsStringAsync().Result);
                 Console.WriteLine(result.Headers);
                 Console.WriteLine(result.Headers.ToString());
                 */

                /*
                 * Responses:
                 * 202 (Accepted) -> {}
                 * o [400 | 401 | 403 | 413] que retornan un objeto con los errores -> {"errors": [{"message": ""}]}
                 */

                return HttpStatusCode.Accepted == result.StatusCode;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(new BussinessException(3, ex));
                return false;
            }
        }

        private static CorreoEstructura GetCorreoEstructura(string asunto, string correo, string nombreUsuario, string tituloMensaje, string mensaje)
        {
            var estructura = new CorreoEstructura
            {
                correoDestinatario = correo,
                nombreDestinatario = nombreUsuario,
                Asunto = "MDA plataforma, " + asunto.ToLower(),
                ContenidoTextoPlano = mensaje,
                PlantillaContenidoHtml =
"<!DOCTYPE html><html lang=\"es\"><head>" +
"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />" +
"<link href=\"https://fonts.googleapis.com/css?family=Roboto\" rel=\"stylesheet\">" +
 "<style type=\"text/css\">" +
 "body {margin: 0; padding: 0; min-width: 100%!important;}" +
 "h1{display: inline-block;font-size: 1.99rem;text-align: left;margin-left: 50px;color: #375a7f;}" +
"h2{text-align: center;font-size: 30px;margin-bottom: 50px;color: #232f34;}" +
".container{display: block;margin:0;background: #fff;width: 80%;text-align: center;padding: 10px;}" +
".btnContainer{display: block;margin: 0 auto;background: #fff;width: 100%;text-align: center;padding: 10px;height: 5%;}" +
"a{text-align: right;text-decoration: none;padding: 10px;background: #ffffff;color: #344955;font-size: 22px;display: inline-block;margin-left: 10px;}" +
" a:hover{background: #ffffff;cursor: pointer;transition: all 300ms ease;}" +
"p{font-size: 22px;color: #344955;text-align: left;} span{color: #344955;}" +
"</style></head>" +
"<body bgcolor=\"#ffffff\">" +
"<div class=\"container\">" +
"<h1>" + tituloMensaje + "</h1>" +
"<h2><i>Estimado(a) " + nombreUsuario + "</i></h2>" +
"<p>" + mensaje + "</p>" +
"<div class=\"btnContainer\"><a href=\"http://localhost:61102\" target=\"_blank\">MDA</a></div>   " +
"</div>" +
"</body> " +
"</html> "
            };
            return estructura;
        }

    }
}
