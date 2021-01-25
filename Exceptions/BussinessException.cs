using Entities_POJO;
using System;

namespace Exceptions
{
    public class BussinessException : Exception
    {
        public int ExceptionId;
        public string ExceptionDetails { get; set; }
        public ApplicationMessage AppMessage { get; set; }

        public BussinessException() { }
        public BussinessException(int exceptionId)
        {
            ExceptionId = exceptionId;

            if (this.InnerException != null)
                ExceptionDetails = this.InnerException.Message;
            else
                ExceptionDetails = this.Message;
        }
        public BussinessException(int exceptionId, Exception innerException)
        {
            ExceptionId = exceptionId;

            if (innerException != null)
            {
                if (innerException.InnerException != null)
                    ExceptionDetails = innerException.InnerException.Message;
                else
                    ExceptionDetails = innerException.Message;
            }
            else
            {
                if (this.InnerException != null)
                    ExceptionDetails = this.InnerException.Message;
                else
                    ExceptionDetails = this.Message;
            }
        }
        public BussinessException(string message)
        {
            if (this.InnerException != null)
                ExceptionDetails = this.InnerException.Message;
            else
                ExceptionDetails = this.Message;

            int value = 0;
            if (int.TryParse(message, out value))
            {
                ExceptionId = value;
            }
            else
            {
                ExceptionId = -1;
                AppMessage = new ApplicationMessage
                {
                    Id = 0,
                    Message = message
                };
            }
        }
    }
}
