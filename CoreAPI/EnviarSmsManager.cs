using Entities_POJO;
using Exceptions;
using System;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CoreAPI
{
    public class EnviarSmsManager : BaseManager
    {
        const string accountSID = "";
        const string authToken = "";

        // Initialize the TwilioClient.

            public void ejecutarEnvioSMS(DatosAuxiliaresSmsCorreo psms)
        {
            TwilioClient.Init(accountSID, authToken);
                try
                {                
                    var message = MessageResource.Create(
                    to: new PhoneNumber("+506"+psms.Telefono),
                    from: new PhoneNumber("") ,
                    body: psms.MensajeSMS);
                }
                    catch (TwilioException ex)
                    {
                ExceptionManager.GetInstance().Process(new BussinessException(0));
            }
        }
       
    }
}
