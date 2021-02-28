using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace LearnApi.InterviewQuestions
{
    public class HtmlResponseMessageController : ApiController
    {
        public HttpResponseMessage Get()
        {
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK, "value");
            responseMessage.Content = new StringContent("Testing", Encoding.Unicode);
            responseMessage.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return responseMessage;
        }
    }
}