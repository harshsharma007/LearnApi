using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers
{
    //Web Api Characteristics
    //1. Web Api is an ideal platform for building RESTful services.
    //2. Web Api is built on top of ASP.Net and supports ASP.Net request/response pipeline.
    //3. Web Api maps HTTP verbs to method names.
    //4. Web Api supports different formats of response data. Built in support for JSON, XML, BSON format.
    //5. Web Api can be hosted in IIS, Self-hosted or other web server that supports .Net 4.0+.
    //6. Web Api framework includes new HttpClient to communicate with Web Api server. HttpClient can be used in ASP.MVC server side, Windows Form Application,
    // Console application or other apps.

    //Web Api versions
    //Web API Version           Supported.NET Framework         Coincides with      Supported in
    //Web API 1.0	            .NET Framework 4.0	            ASP.NET MVC 4	    VS 2010
    //Web API 2 - Current       .NET Framework 4.5	            ASP.NET MVC 5	    VS 2012, 2013
    public class WebapiVsWcfController : ApiController
    {
        public void Post([FromBody]string value)
        {

        }
    }
}
