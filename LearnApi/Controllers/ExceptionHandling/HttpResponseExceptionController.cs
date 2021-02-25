using System;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers.ExceptionHandling
{
    public class HttpResponseExceptionController : ApiController
    {
        /*
            HttpResponseException is the Level 1 for exception handling, which occurs at method level.
        */

        [Route("CheckId/{Id}")]
        [HttpGet]
        public IHttpActionResult CheckId(int Id)
        {
            if (Id > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Ok(Id);
        }

        /*
            If we run the below URL on Postman, then it will work fine and will return a Status of 200 - OK.
            
            http://localhost:49440/HttpResponseException/CheckId/4
            
            But, if we hit an ID with is greater than 100 then what will happen? It will return a Status Code of 500 - Internal Server Error. So what does that mean?
            To the consumer, this is equivalent of saying "an error occurred" and not getting any further explanation. Instead of just throwing a naked exception, let's
            return a message to the consumer with a better explanation of what happened.
            
            In our case, since we used an invalid ID, let's return 400 - Bad Request to better describe the error. We can do this by using the HttpResponseException
            class.
        */

        [Route("CheckIdWithExceptionHandling/{Id}")]
        [HttpGet]
        public IHttpActionResult CheckIdWithExceptionHandling(int Id)
        {
            if (Id > 100)
            {
                var message = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("We cannot use IDs greater than 100.")
                };
                throw new HttpResponseException(message);
            }
            return Ok(Id);
        }

        // You could also just build the request in the action itself:

        [Route("HttpError")]
        [HttpGet]
        public HttpResponseMessage HttpError()
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.Forbidden, "You cannot access this method at this time.");
        }

        // There are also some shortcut methods for commonly-used status codes:

        [Route("Forbidden")]
        [HttpGet]
        public IHttpActionResult Forbidden()
        {
            return Forbidden();
        }

        [Route("OK")]
        [HttpGet]
        public IHttpActionResult OK()
        {
            return OK();
        }

        [Route("NotFound")]
        [HttpGet]
        public IHttpActionResult NotFound()
        {
            return NotFound();
        }
    }
}