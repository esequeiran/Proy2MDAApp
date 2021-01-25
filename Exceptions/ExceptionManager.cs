using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Web;

namespace Exceptions
{
    public class ExceptionManager 
    {
        public string PATH = "";

        private static ExceptionManager instance;

        private static Dictionary<int, ApplicationMessage> messages = new Dictionary<int, ApplicationMessage>();

        private ExceptionManager() // es privado por ser singleton
        {
            LoadMessages();

            // Crea la carpeta "_logs" en WebAPI.
            this.PATH = Path.Combine(HttpContext.Current.Server.MapPath("~/"), "_logs");
        }

        public static ExceptionManager GetInstance()
        {
            if (instance == null)
                instance = new ExceptionManager();

            return instance;
        }

        public void Process(Exception ex)
        {

            var bex = new BussinessException();

            if (ex.GetType() == typeof(BussinessException))
            {
                bex = (BussinessException)ex;
                bex.ExceptionDetails = GetMessage(bex).Message;
            }
            else
            {
                bex = new BussinessException(0, ex);
            }

            ProcessBussinesException(bex);

        }

        private void CrearCarpeta(string directoryName)
        {
            if (!Directory.Exists(directoryName))
            {
                DirectorySecurity securityRules = new DirectorySecurity();

                IdentityReference todos = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                securityRules.AddAccessRule(new FileSystemAccessRule(todos, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));

                _ = Directory.CreateDirectory(directoryName, securityRules);
            }
        }

        private void ProcessBussinesException(BussinessException bex)
        {
            var today = DateTime.Now.ToString("yyyyMMdd_hh");
            var logName = Path.Combine(PATH, today + "_" + "log.txt");

            //Crea la carpeta si no existe:
            CrearCarpeta(PATH);

            if (-1 == bex.ExceptionId)
            {
                bex.ExceptionId = 0;
            }
            else
            {
                bex.AppMessage = GetMessage(bex);
            }

            var message = ":\n" + bex.ExceptionDetails + "\n" + bex.StackTrace + "\n\n";

            using (StreamWriter w = File.AppendText(logName))
            {
                Log(bex.ExceptionId + " - " + bex.AppMessage.Message + message, w);
            }

            throw bex;

        }



        public ApplicationMessage GetMessage(BussinessException bex)
        {

            var appMessage = new ApplicationMessage
            {
                Message = "Message not found!"
            };

            if (messages.ContainsKey(bex.ExceptionId))
                appMessage = messages[bex.ExceptionId];

            return appMessage;

        }

        private void LoadMessages()
        {
         
            var crudMessages = new AppMessagesCrudFactory();
            var lstMessages = crudMessages.RetrieveAll<ApplicationMessage>();
            foreach(var appMessage in lstMessages)
            {
                messages.Add(appMessage.Id, appMessage);
            }  

        }

        private void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }
}
