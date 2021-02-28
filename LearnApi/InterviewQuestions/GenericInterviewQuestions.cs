using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnApi.InterviewQuestions
{
    public class GenericInterviewQuestions
    {
        /*
            01. What is Web API?
                Web API is a framework which helps you to build/develop HTTP services.
            
            02. Why is Web API required? Is it possible to use RESTful services using WCF?
                Yes, we can still develop RESTful services with WCF. However, there are two main reasons that prompt users to use Web API instead of RESTful services.
                - Web API increases TDD (Test Data Driven) approach in the development of RESTful services.
                - If we want to develop RESTful services in WCF, you surely need a lot of config settings, URI templates, contracts & endpoints for developing RESTful
                  services using Web API.
            
            03. Why select Web API?
                - It is used to create simple, non-SOAP-based HTTP services.
                - It is lightweight architecture and ideal for devices that have limited bandwidth like smartphones.
            
            04. Is it right that ASP.NET Web API has replaced WCF?
                It's not at all true that ASP.NET Web API has replaced WCF. In fact, it is another way of building non-SOAP based services, i.e. plain XML or JSON string.
            
            05. What are the advantages of Web API?
                - OData
                - Filters
                - Content Negotiation
                - Self-Hosting
                - Routing
                - Model Bindings
            
            06. What are the main return types supported in Web API?
                A Web API controller action can return following values:
                - Void - It will return empty content
                - HttpResponseMessage - It will convert the response to an HTTP message
                - IHttpActionResult - Internally calls ExecuteAsync to create an HttpResponseMessage
                - Other types - You can write the serialized return value into the response body
            
            07. Web API supports which protocol?
                Web API supports HTTP protocol
            
            08. Which .NET framework supports Web API?
                NET 4.0 and above version supports Web API
            
            09. Web API uses which of the following open-source library for JSON serialization?
                Web API uses Json.NET library for JSON serialization.
            
            10. By default, Web API sends HTTP response with which of the following status code for all uncaught exception?
                500 - Internal Server Error
            
            11. What is the biggest disadvantage of "Other Return Types" in Web API?
                The biggest disadvantage of this approach is that you cannot directly return an error code like 404 error.
            
            12. How do you construct HtmlResponseMessage?
                See code in HtmlResponseMessageController
            
            13. What is Web API Routing?
                Routing is pattern matching like in MVC. All routes are registered in Route Tables. For example:
                
                Routes.MapHttpRoute (
                    Name: "ExampleWebAPIRoute",
                    routeTemplate: "api/{controller}/{id},
                    defaults: new { id = RouteParameter.Optional }
                )
            
            14. What is SOAP?
                SOAP is an XML message format used in web service interactions. It allows to send messages over HTTP or JMS, but other transport protocols can be used.
                It is also an XML-based messaging protocol for exchanging information among computers.
            
            15. What is the benefit of using REST in Web API?
                REST is used to make fewer data transfers between client and server which make it an ideal for using it in mobile apps. Web API also supports HTTP
                protocol. Therefore, it reintroduces the traditional way of the HTTP verbs for communication.
        */
    }
}