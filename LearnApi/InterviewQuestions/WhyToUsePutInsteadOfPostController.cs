using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.InterviewQuestions
{
    public class WhyToUsePutInsteadOfPostController : ApiController
    {
        /*
            Q. Why to use HTTP PUT when same can be done with HTTP POST in Web API?
            
            1. The advantage is mostly semantic, and can also simplify URLs to an extent. The different HTTP methods map to different actions:
            
            POST -> Create a new object
            DELETE -> Delete an object
            PUT -> Modify an object
            GET -> View an object
            
            Then, in theory, you can use the same URL, but interact with it using different methods; the method used to access the resource defines the actual type of
            operation.
            
            In practice, though, most browsers only support HTTP GET and POST.
            
            2. Using bad practices, I can upload something, update something or even create a new record all using the GET method HTTP request. I can pass the data
            which is to be saved as a query string and there, it is saved. That is not the good way of using the HTTP verbs when you are going to publish the API
            someday for public. That is why, you should always go and read the actual documentations before doing something.
            
            Anyways, the HTTP verbs are used as:
            1. HTTP GET: For requesting to get the resource at that URI.
            2. HTTP DELETE: For requesting to delete the resource at that URI.
            3. HTTP POST: For requesting to upload and save the data being uploaded to the data. Server then stores the entity and provides a new URI for that resource.
            4. HTTP PUT: Same as POST but with a condition that it checks if that resource is already saved. If that resource is available then it simply updates.
        */
    }
}
