using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers
{
    /*
        Web API handles different formats of request and response data. Below are the details:
        
        Media Type
        Media type(aka MIME type) specifies the format of the data as type/subtype e.g. text/html, text/xml, application/json, image/jpeg etc.
        In HTTP request, MIME type is specified in the request header using Accept and Content-Type attribute. The Accept header attribute specifies the format of
        response data which the client expects and the Content-Type header attribute specifies the format of the data in the request body so that receiver can parse
        it into appropriate format.

        For example, if a client wants response data in JSON format then it will send following GET HTTP request with Accept header to the Web API.

        HTTP GET Request:
        GET http://localhost:1000/api/student HTTP/1.1
        User-Agent: Fiddler
        Host: localhost:1000
        Accept: application/json

        The same way, if a client includes JSON data in the request body to send it to the receiver then it will send following POST HTTP request with Content-Type
        header with JSON data in the body.

        HTTP POST Request:
        POST http://localhost:1000/api/student?age=15 HTTP/1.1
        User-Agent: Fiddler
        Host: localhost:1000
        Content-Type: application/json
        Content-Length: 13

        {
            id: 1,
            name: 'Steve'
        }

        Web API converts request data into CLR object and also serialize CLR object into response data based on Accept and Content-Type headers. Web API includes
        built-in support for JSON, XML, BSON and form-urlencoded data. It means it automatically converts request/response data into these formats OOB(out-of the box).
    */
    public class DataFormatsController : ApiController
    {
        public Student Post(Student student)
        {
            // save student into db
            //var insertedStudent = SaveStudent(student);
            //return insertedStudent;
            
            return null;
        }

        /*
            As you can see above, the Post() action method accepts Student type parameter, saves that student into DB and returns inserted student with generated Id.
            The above Web API handles HTTP POST request with JSON or XML data and parses it to a Student object based on Content-Type header value and the same way
            it converts insertedStudent object into JSON or XML based on Accept header value.
        */
    }
}
