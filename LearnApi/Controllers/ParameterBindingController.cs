using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //Action methods in Web API controller can have one or more parameters of different types. It can be either primitive type or complex type. Web API binds action
    //method parameters either with URL's query string or with request body depending on the parameter type. By default, if parameter type is of .NET primitive type
    //such as int, bool, double, string, GUID, DateTime, decimal or any other type that can be converted from string type then it sets the value of a parameter
    //from the query string. And if the parameter type is complex type then Web API tries to get the value from request body by default.

    //The following table lists the default rules for parameter binding
    //HTTP Method                       Query String                            Request Body
    //GET                           Primitive Type, Complex Type                NA
    //POST                          Primitive Type                              Complex Type
    //PUT                           Primitive Type                              Complex Type
    //PATCH                         Primitive Type                              Complex Type
    //Delete                        Primitive Type, Complex Type                NA

    //Get action method with primitive parameter
    //Consider the following example of Get action method that includes single primitive type parameter.
    public class ParameterBindingController : ApiController
    {
        public void Get(int Id)
        {
            //As you can see above Get action method includes Id parameter of int type. So, Web API will try to extract the value of Id from the query string of
            //request URL, convert it into int and assign it to Id parameter of Get action method.
            //For example, if an HTTP request is http://localhost:1000/api/student?Id=1 then value of id parameter will be 1.

            //Followings are valid HTTP GET Requests for the above action method.
            //http://localhost:1000/api/student?Id=1
            //http://localhost:1000/api/student?ID=1

            //NOTE
            //Query string parameter name and action method parameter name must be the same (case-insensitive). If names do not match then values of the parameters will
            //not be set. The order of the parameters can be different.
        }

        //Multiple primitive parameters
        //Consider the following example of Get action method with multiple primitive parameters.

        public void Get(int Id, string Name)
        {
            //As you can see above, Get method includes multiple primitive type parameters. So, Web API will try to extract the values from the query string of requested
            //URL.
            //For example, if an HTTP request is http://localhost:1000/api/student?Id=1&Name=Harsh then value of Id parameter will be 1 and Name will be "Harsh".

            //Followings are valid HTTP GET Requests for the above action method.
            //http://localhost:1000/api/student?Id=1&Name=steve
            //http://localhost:1000/api/student?ID=1&NAME=steve
            //http://localhost:1000/api/student?name=steve&id=1

            //NOTE
            //Query string parameter names must match with the name of an action method parameter. However, they can be in differnt order.
        }

        //POST action method with primitive parameter
        //HTTP POST request is used to create new resource. It can include request data into HTTP request body and also in query string.

        public void Post(int Id, string Name)
        {
            //As you can see above, Post() action method includes primitive type parameters Id and Name. So, by default, Web API will get values from the query string.
            //For example, if an HTTP POST request is http://localhost:1000/api/student?Id=1&Name=Steve then the value of Id will be 1 and Name will be "Steve".
        }

        //Now consider the following Post() method with complex type parameter.
        public Student Post(Student student)
        {
            //The above Post() method includes Student type parameter. So, as a default rule, Web API will try to get the values of student parameter from HTTP request
            //body.

            //Following is a valid HTTP POST request
            //{
            //  Id: 1,
            //  Name: 'Steve'
            //}

            //Web API will extract the JSON object from the Request body above and convert it into Student object automatically because names of JSON object properties
            //matches with the name of Student class properties (case-insensitive).

            return student;
        }

        //POST method with mixed parameters
        //Post action method can include primitive and complex type parameters.
        public Student Post(int age, Student student)
        {
            //The above Post method includes both primitive and complex type parameter. So, by default, Web API will get the Id parameter from query string and Student
            //parameter from the request body.

            //Following is a valid HTTP POST request
            //http://localhost:1000/api/student?age=25
            //Request Body
            //{
            //  Id: 1,
            //  Name: 'Steve'
            //}

            //Post action method cannot include multiple complex type parameters because at most one parameter is allowed to be read from the request body.
            //Parameter binding for Put and Patch method will be the same as Post method in Web API.

            return student;
        }

        //[FromUri] and [FromBody]
        //You have seen that by default Web API gets the value of a primitive parameter from the query string and complex type parameter from the request body.
        //But, what if we want to change this default behavior?

        //Use [FromUri] attribute to force Web API to get the value of complex type from the query string and [FromBody] attribute to get the value of primitive type
        //from the request body, opposite to the default rules.

        public Student Get([FromUri] Student student)
        {
            //In the above example, Get method includes complex type parameter with [FromUri] attribute. So, Web API will try to get the value of Student type
            //parameter from the query string.
            //For example, if an HTTP GET request http://localhost:1000/api/student?Id=1&Name=Steve then Web API will create Student object and set its Id and Name
            //property to the value of Id and Name from query string.

            return student;

            //NOTE
            //Name of the complex type properties and query string parameters must match.
        }

        //The same way, consider the following example of Post method.
        public Student PostStudent([FromUri] Student student)
        {
            //As you can see above, we have applied [FromUri] attribute with the Student parameter. Web API by default extracts the value of complex type from
            //request body but here we have applied [FromUri] attribute. So now, Web API will extract the value of Student properties from the query string instead
            //of request body.

            return student;
        }

        //The same way, apply [FromBody] attribute to get the value of primitive data type from the request body instead of query string, as shown below.
        public Student PostStudentNew([FromBody] string Name)
        {
            //Following is a valid HTTP POST request.
            //Request Body
            //"Steve"

            return null;

            //NOTE
            //FromBody attribute can be applied on only one primitive parameter of an action method. It cannot be applied on multiple primitive parameters of the
            //same action method.
        }

        //The following figure summarizes parameter binding rules. (Web API Parameter Bindings)
        //Action Parameter Type                     Binding Source
        //Primitive                     ->          Query String
        //Complex                       ->          Request Body
        //[FromBody] Primitive          ->          Request Body
        //[FromUri] Complex             ->          Query String
    }
}