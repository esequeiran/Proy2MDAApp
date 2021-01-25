using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebAPI.Models
{
    public class EnviarCorreoManager
    {
        
        public EnviarCorreoManager()
        {

        }
        public void ejecutarCorreo(CorreoEstructura correo)
        {
            var apiKey = "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";
            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress("aureo.soft4@gmail.com", "Aureosoft-MDA");
            var subject = correo.Asunto;
            var to = new EmailAddress(correo.correoDestinatario, correo.nombreDestinatario);
            var plainTextContent = correo.ContenidoTextoPlano;
            var htmlContent = correo.PlantillaContenidoHtml;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = cliente.SendEmailAsync(msg);
        }
    }
}