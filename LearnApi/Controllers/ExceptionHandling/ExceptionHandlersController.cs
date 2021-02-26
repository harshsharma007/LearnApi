using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace LearnApi.Controllers.ExceptionHandling
{
    public class ExceptionHandlersController : ApiController
    {
        /*
            This is the last level of Exception. Exception Handlers are called after Exception Filters and Exception Loggers, and only if the exception has not already
            been handled. Normally, exception filter is used to catch the unhandled exception. This approach will work fine but it fails if any error is raised from
            outside. For example, if any error is raised in the following area then exception filter will not work.
            
            - Error inside the exception filter.
            - Exception related to routing.
            - Error inside the Message Handlers class.
            - Error in Controller Constructor.
            
            Using the following code, we can define the custom implementation of ExceptionHandler.
            
            The handler, like the logger, must be registered in the Web API Configuration. Note that we can only have one Exception Handler per application.
            
            Now, let's add a new controller action, ArgumentNull()
        */

        [Route("ArgumentNull/{id}")]
        [HttpPost]
        public IHttpActionResult ArgumentNull(int Id)
        {
            return Ok(new ArgumentNullException());
        }
    }

    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is ArgumentNullException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ArgumentNullException"
                };

                context.Result = new ArgumentNullResult(context.Request, result);
            }
        }
    }

    public class ArgumentNullResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private HttpResponseMessage _httpResponseMessage;

        public ArgumentNullResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        {
            _request = request;
            _httpResponseMessage = httpResponseMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_httpResponseMessage);
        }
    }
}