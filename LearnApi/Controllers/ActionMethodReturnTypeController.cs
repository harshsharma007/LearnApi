using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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
            
            In the above figure, the Web API returns HttpResponseMessage object. You can also create and return an object of HttpResponseMessage directly from an
            action method. The advantage of sending HttpResponseMessage from an action method is that you can configure a response your way. You can set the status
            code, content or error message as per your requirement.
         */

        public HttpResponseMessage Get(int Id)
        {
            if (Id < 1)
                return Request.CreateResponse(HttpStatusCode.NotFound, Id);

            return Request.CreateResponse(HttpStatusCode.OK, Id);
        }

        /*
            In the above action method, if there is no student with specified Id in the DB then it will return HTTP 404 Not Found status code, otherwise it will return
            200 OK Status with student data.
        */

        /*
            IHttpActionResult
            The IHttpActionResult was introduced in Web API 2.0 (.Net 4.5). An action method is Web API 2 can return an implementation of IHttpActionResult class
            which is more or less similar to ActionResult class in ASP.NET MVC.

            You can create your own class that implements IHttpActionResult or use various methods of ApiController class that returns an object that implement the
            IHttpActionResult.
        */

        public IHttpActionResult GetStudentInfo(int Id)
        {
            Student student = new Student();
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        /*
            In the above example, if student with specified Id does not exists in the database then it will return response with the status code 404 otherwise it sends
            data with status code 200 as a response. As you can see, we don't have to write much code because NotFound() and Ok() methods do it all for us.

            The following table lists all the methods of ApiController class that returns an object of a class that implements IHttpActionResult interface.

            ApiController Method            Description
            BadRequest()                    Creates a BadRequestResult object with status code 400.
            Conflict()                      Creates a ConflictResult object with status code 409.
            Content()                       Creates a NegotiatedContentResult with the specified status code and data.
            Created()                       Creates a CreatedNegotiatedContentResult with status code 201 created.
            CreatedAtRoute()                Creates a CreatedAtRouteNegotiatedContentResult with status code 201 created.
            InternalServerError()           Creates an InternalServerErrorResult with status code 500 internal server error.
            NotFound()                      Creates a NotFoundResult with status code 404.
            Ok()                            Creates an OkResult with status code 200.
            Redirect()                      Creates a RedirectResult with status code 302.
            RedirectToRoute()               Creates a RedirectToRoute with status code 302.
            ResponseMessage()               Creates a ResponseMessageResult with the specified HttpResponseMessage.
            StatusCode()                    Creates a StatusCodeResult with the specified http status code.
            Unauthorized()                  Creates an UnauthorizedResult with status code 401.
        */

        public IHttpActionResult GetNames(int Id)
        {
            if (Id < 1)
                return NotFound();

            return new TextResult("", Request);
        }
    }

    /*
        Create Custom Result Type
        You can create your own custom class as a result type that implements IHttpActionResult interface.
    */
    public class TextResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;

        public TextResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}
