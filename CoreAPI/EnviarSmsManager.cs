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
        const string accountSID = "AC4f31a3c7317e32870c350f13d22b6cf5";
        const string authToken = "4981e6d07e93585295afde4488cc261f";

        // Initialize the TwilioClient.

            public void ejecutarEnvioSMS(DatosAuxiliaresSmsCorreo psms)
        {
            TwilioClient.Init(accountSID, authToken);
                try
                {                
                    var message = MessageResource.Create(
                    to: new PhoneNumber("+506"+psms.Telefono),
                    from: new PhoneNumber("+12055396452") ,
                    body: psms.MensajeSMS);
                }
                    catch (TwilioException ex)
                    {
                ExceptionManager.GetInstance().Process(new BussinessException(0));
            }
        }
       
    }
}
