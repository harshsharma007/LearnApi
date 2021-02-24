using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers
{
    /*
        Full form of REST is Representational State Transfer

        Web Api Characteristics
        1. Web Api is an ideal platform for building RESTful services.
        2. Web Api is built on top of ASP.Net and supports ASP.Net request/response pipeline.
        3. Web Api maps HTTP verbs to method names.
        4. Web Api supports different formats of response data. Built in support for JSON, XML, BSON format.
        5. Web Api can be hosted in IIS, Self-hosted or other web server that supports .Net 4.0+.
        6. Web Api framework includes new HttpClient to communicate with Web Api server. HttpClient can be used in ASP.MVC server side, Windows Form Application,
         Console application or other apps.

        Web Api versions
        Web API Version           Supported.NET Framework         Coincides with      Supported in
        Web API 1.0	              .NET Framework 4.0	            ASP.NET MVC 4	    VS 2010
        Web API 2 - Current       .NET Framework 4.5	            ASP.NET MVC 5	    VS 2012, 2013
    */

    public class Name
    {
        public string value { get; set; }
    }

    public class WebapiVsWcfController : ApiController //Without using HTTP verbs.
    {
        /*
            Web api vs Wcf
            Web api                                                       Wcf
            Open source and ships with .Net framework                     Ships with .Net framework.
            Supports only HTTP protocol                                   Supports HTTP, TCP, UDP and custom transport protocol.
            Maps http verbs to methods                                    Uses attributes based programming model.
            Uses routing and controller concept similar to MVC            Uses Service, Operation and Data Contracts.
            Does not support Reliable Messaging and transaction           Supports Reliable Messaging and Transactions.
            Web api can be configured using HTTPConfiguration class       Uses web.config and attributes to configure a service.
            but not in web.config
            Ideal for building RESTful services                           Supports RESTful services with limitations.
        */

        public void Post([FromBody]string name)
        {
            /*
                To pass value to this method, the type selected must be "post" and in postman body "raw" should be selected as an option and the request must be
                send in JSON format only.
                Sample format of request
                "Harsh" -> this is the way to assign value to parameter name
            */
        }

        /*
            When to choose Web Api
            If you are using .Net framework 4.0 or above.
            If you want to build a service that supports only HTTP Protocol.
            If you want to build RESTful HTTP based services.
            If you are familiar with ASP.NET MVC.
        */

        public void Get(Name name)
        {
            /*
                To pass value to this method, the type selected must be "Get" and in postman body "raw" should be selected as an option and the request must be send in
                JSON format only.
                
                Sample format of the request
                {
                  "value" : "Harsh"
                }
                
                When it comes to sending a value to an object, then the name of the property must be assigned with a value.
                As in above example "value" is used, not the variable "name".
            */
        }

        public void Put(int id, [FromBody] string value)
        {
            /*
                To pass value to this method, the type selected must be "Put" and in postman body "raw" should be selected as an option and the request must be send in 
                JSON format only.
                
                Sample format of the request
                Url: http://localhost:64808/api/WebapiVsWcf/44
                "Harsh" -> will be written in body.
            */
        }

        public void Delete(int id)
        {
            /*
                To pass value to this method, the type selected must be "Delete".
                Sample format of request
                Url: http://localhost:64808/api/WebapiVsWcf/44
            */
        }
    }

    /*
        Difference between Web Api and MVC Controller
        Web Api Controller                                                    MVC Controller
        Derives from System.Web.Http.ApiController class                      Derives from System.Web.Mvc.Controller class.
        Method name must start with Http verbs otherwise                      Must apply appropriate Http verbs attribute.
        apply http verbs attribute.
        Specialized in returning data.                                        Specialized in rendering view.
        Return data automatically formatted based on Accept-Type              Returns ActionResult or any derived type.
        header attribute. Default to json or xml.
        Requires .Net 4.0 or above.                                           Requires .Net 3.5 or above.
    */
}
