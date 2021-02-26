using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace LearnApi.Controllers.ExceptionHandling
{
    public class ExceptionLoggerController : ApiController
    {
        /*
            Logging is the 3rd level. You can use the built-in ExceptionLogger class that logs any exception in the application. Below is the code for this.
            
            To use this class in our Web API service, we need to register it. In the WebApiConfig file (or whatever file you are using to configure the service) we
            need to replace the default ExceptionLogger instance which Web API automatically adds to the services with our own implementation:
            
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());
            
            Now, any time an unhandled exception is thrown anywhere in the service, the logger will catch it, and you can write whatever logging code you wish to use.
        */
    }

    public class UnhandledExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            context.Exception.ToString();
        }
    }
}