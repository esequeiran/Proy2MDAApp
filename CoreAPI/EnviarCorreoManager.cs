using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Entities_POJO;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CoreAPI
{
    public class EnviarCorreoManager
    {
        
        public EnviarCorreoManager()
        {

        }
        public void ejecutarCorreo(CorreoEstructura correo)
        {
            try
            {
                //var apiKey = "";
              
                var cliente = new SendGridClient(apiKey);
                var from = new EmailAddress("aureo.soft4@gmail.com", "Aureosoft-MDA");
                var subject = correo.Asunto;
                var to = new EmailAddress(correo.correoDestinatario, correo.nombreDestinatario);
                var plainTextContent = correo.ContenidoTextoPlano;
                var htmlContent = correo.PlantillaContenidoHtml;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = cliente.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {

            }
            
        }


        public void ejecutarCorreoConAdjunto(CorreoEstructura correo)
        {
            try
            {
                //var apiKey = "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";
                var apiKey = "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";
                var cliente = new SendGridClient(apiKey);
                var from = new EmailAddress("aureo.soft4@gmail.com", "Aureosoft-MDA");
                var subject = correo.Asunto;
                var to = new EmailAddress(correo.correoDestinatario, correo.nombreDestinatario);
                var plainTextContent = correo.ContenidoTextoPlano;
                var htmlContent = correo.PlantillaContenidoHtml;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
               //
              
                msg.Attachments = new List<SendGrid.Helpers.Mail.Attachment>
                {
                new SendGrid.Helpers.Mail.Attachment
                {
                    Content = Convert.ToBase64String(correo.AdjuntoQR),
                    Filename = "CodigoQr.jpeg",
                    Type = "image/jpeg",
                    Disposition = "attachment"
                }
                };
                //
                var response = cliente.SendEmailAsync(msg);


            }
            catch (Exception ex)
            {

            }

        }

    }
}
