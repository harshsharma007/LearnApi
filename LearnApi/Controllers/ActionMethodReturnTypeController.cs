using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /*
        The Web API action method can have following return types:
        1. Void
        2. Primitive type or Complex type
        3. HttpResponseMessage
        4. IHttpActionResult
    */
    
    public class ActionMethodReturnTypeController : ApiController
    {
        /*
            Void
            It's not necessary that all action methods must return something. It can have void return type.
        */
        public void Delete(int Id)
        {
            //It will send 204 "No Content" status code as a response when you send HTTP DELETE request.
        }

        /*
            Primitive type or Complex type
            An action method can return primitive type or other complex types as other normal methods.
        */
        public int GetId(string Name)
        {
            return 1;
            //http://localhost:1000/api/Student?Name=John
        }

        public Student GetStudent(int Id)
        {
            return null;
            //http://localhost:1000/api/Student?Id=1
        }

        /*
            HttpResponse Message
            Web API controller always return an object of HttpResponseMessage to the hosting infrastructure. The following figure illustrates the overall Web API
            request/response pipeline.

                        HttpRequest                           HttpRequestMessage              HttpRequestMessage + Model
                        ------------>                           ------------>                       ------------>
                Client                  Web API Hosting Server                  Web API Controller                  Action Method
                        <------------                           <------------                       <------------
                        HttpResponse                          HttpResponseMessage                       Result
        */
    }
}
