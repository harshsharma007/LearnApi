using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LearnApi.Understanding
{
    public class CORSController : ApiController
    {
        /*
            Introduction
            Nowadays, ASP.NET WebAPI is a trending technology. Everyone is trying to access the service through AJAX requests or server side. Problem is when a WebAPI 
            is hosted and the other application (different domain) tries to access the WebAPI through an AJAX request. Here, enabling CORS plays a vital role in WebAPI.
            
                                                                             +--------------------------+
            +----------------------+    Sends AJAX Request                   |                          |
            | http://localhost.com |---------------------------------------->|                          |
            +----------------------+  Request Success due to same domain     |                          |
                                                                             | http://localhost.com/api |
            +----------------------+    Sends AJAX Request                   |                          |
            | http://domain1.com   |---------------------------------------->| Note: CORS is enabled    |
            +----------------------+  Request Fails due to diff domain name  | for domain2.com site.    |
                                                                             |                          |
            +----------------------+    Sends AJAX Request                   |                          |
            | http://domain2.com   |---------------------------------------->|                          |
            +----------------------+  Request Success due to CORS is enabled |                          |
                                        for this domain in Server            |                          |
                                                                             +--------------------------+
            
            In the above figure, we have hosted one WebService at localhost.com. We are sending 3 AJAX requests to get the response from WebService:
            - Same domain, other domain (domain1.com), other domain (domain2.com) with CORS enabled.
            
            1. When the Request comes from same domain, it works perfectly.
            
            2. When the Request comes from some other domain(domain1.com), it throws an error. It means, the browser has a property called Access-Control-Allow-Origin 
            which restricts the requests from different domains for security purposes. So, we need to enable CORS to accomplish the request.
            
            Error: XMLHttpRequest cannot load http://localhost:1312/api/Blog?type=json. No 'Access-Control-Allow-Origin' header is present on the requested resource.
            Origin 'http://localhost' is therefore not allowed access.
            
            3. From the above discussion, we need to enable CORS in Server-to-Server requests. Request comes from the other domain, it works perfectly because CORS is 
            enabled. 
            
            Before starting the discussion, here are some terminologies and their definition:
            
            What is WebAPI?
            ASP.NET Web API is a framework which is used to make it easy to build HTTP services that reach a broad range of clients, including browsers and mobile 
            devices. ASP.NET Web API is an ideal platform for building RESTful applications on the .NET framework. Moreover, Web API is open source and an ideal platform 
            for building REST-ful services over the .NET framework. It uses HTTP methods mainly GET, POST, PUT, DELETE to communicate with client.
            
            What is CORS?
            CORS stands for Cross-Origin Resource Sharing. It is a mechanism that allows restricted resources on a web page to be requested from another domain, outside 
            the domain from which the resource originated. A web page may freely embed images, stylesheets, scripts, iframes, and videos.
            
            For security reasons, browsers restrict cross-origin HTTP requests initiated from within scripts. For example, XMLHttpRequest follows the same-origin policy. 
            So, a web application using XMLHttpRequest could only make HTTP requests to its own domain. To improve web applications, developers asked browser vendors to 
            allow XMLHttpRequest to make cross-domain requests.
            
            What is same origin policy?
            Browsers allow a web page to make AJAX requests only within the same domain. Browser security prevents a web page from making AJAX requests to another domain. 
            This is called origin policy.
            
            We can enable CORS in WebAPI,
            1. Using JSONP
            2. Using Microsoft.AspNet.WebApi.Cors
            
            Using JSONP(JSON with Padding) formatter
            
            What is JSONP?
            JSONP stands for JSON with Padding. It helps to implement cross-domain request by browser's same-origin-policy. It wraps up a JSON response into a JavaScript 
            function (callback function) and sends that back as a Script to the browser. This allows you to bypass the same origin policy and load JSON from an external 
            server into the JavaScript on your webpage.
            
            // JSON:
            {  
               'name' : 'manas',  
               'age' : 23,  
               'temper' : 'moody'  
            }
            
            With JSONP, when the server receives the "callback" parameter, it wraps up the result a little differently, and returns like this.
            // JSONP:  
            newPerson({  
               'name' : 'manas',  
               'age' : 23,  
               'temper' : 'moody'  
            });
            
            First, we need to enable CORS in WebAPI, then we call the service from other application AJAX request. In order to enable CORS, we need to install the JSONP 
            package from NuGet.
            
            After adding Jsonp package, we need to add the following code-snippet in App_Start\WebApiConfig.cs file. It creates instance of JsonpMediaTypeFormatter class 
            and adds to config formatters object.
            
            var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);    
            config.Formatters.Add(jsonpFormatter);
            
            Now, we are ready with CORS enabling in Server and the other application needs to send AJAX requests which are hosted on another domain. In the below code 
            snippet, it sends datatype as jsonp which works for cross domain requests.
            
            <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>
            <script>
                $(document).ready(function () {
                    $.ajax({
                        type: 'POST',
                        url: 'http://localhost:1312/api/Blog',
                        cache: 'true',
                        dataType: 'jsonp',
                        success: function (json) {
                            var htmlContent = "";
                            $.each(json, function (key, item) {
                                htmlContent = htmlContent + "<tr><td>" + item.Id + "</td><td>" + item.Name + "</td><td>" + item.Url + "</td></tr>";
                            });
                            $('#blogs').append(htmlContent);
                        },
                        error: function (parsedjson, textStatus, errorThrown) {
                            $('body').append(
                                "parsedJson status: " + parsedjson.status + '</br>' +
                                "errorStatus: " + textStatus + '</br>' +
                                "errorThrown: " + errorThrown);
                        }
                    });
                });
            </script>
            
            Disadvantages
            1. Incompatible in old browser
            2. Security issue which can steal your cookies(leads to a whole bunch of potential problems).
            
            Using Microsoft.AspNet.WebApi.Cors
            To use Microsoft CORS package, you need to install from NuGet package.
            
            Go to Tools Menu-> Library Package Manager -> Package Manager Console -> execute the below command.
            
            Install-Package Microsoft.AspNet.WebApi.Cors
            
            To register/enable CORS we are going to use EnableCorsAttribute class and it takes four params(4th one is optional).
            
            1. Origins
            Here, we need to set Origins which means from which domain the requests will accept. If you have more than one domain, then you can set as comma separated. 
            Additionally if you want any domain request to be accepted then use wild card as "*".
            
            2. Request Headers
            The Request header parameter specifies which Request headers are allowed. To allow any header set value to "*".
            
            3. HTTP Methods
            The methods parameter specifies which HTTP methods are allowed to access the resource. Use comma-separated values when you have multiple HTTP methods like 
            "get,put,post". To allow all HTTP methods, use the wildcard value "*".
            
            4. exposedHeaders
            By default, the browser does not expose all of the response headers to the application. The response headers that are available by default are: 
            Cache-Control, Content-Language, Content-Type, Expires, Last-Modified, Pragma.
            
            To make other headers available in browser you need to use exposedHeaders. You can set custom headers like below code snippet:
        */
    }

    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    public class TestController : ApiController
    {

    }

    /*
        You can configure CORS support for Web API at three levels.
        1. Global level
        2. Controller level
        3. Action level
        
        Global level
        Here, we are going to enable CORS at a Global level, which means it is applicable to all controllers and its actions. You need to add below code-snippet in 
        App_Start/WebApiConfig.cs file. It creates instance of EnableCorsAttribute class with passing required params.
        
        "http://localhost:80/DemoApp/WebForm1.aspx" : Server enables CORS for this domain.
        
        "*" : STAR means it accepts all request headers.
        
        "GET,POST" : It indicates it accepts only GET, POST http verbs. If any request comes to server other than "GET, POST" it throws exception.
        
        public static void Register(HttpConfiguration config)
        {
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:80/DemoApp/WebForm1.aspx", "*", "GET,POST");
            config.EnableCors(cors);
        }
        
        Controller level
        We can enable CORS at Controller level which means all the actions present inside are ready to serve request from cross domain. Here we need to add EnableCors 
        attribute on the top of controller with passing required parameter(same discussed in above).
    */

    [EnableCors(origins: "http://localhost:5901/DemoApp/WebForm1.aspx", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {

    }

    /*
        Action level
        Likewise, at controller level, we can enable CORS at Action level which means CORS is enabled to particular action which is ready to serve request from cross 
        domain. Here, we need to add EnableCors attribute on the top of action with passing required parameter (same discussed in above).
    */

    public class ValuesNewController : ApiController
    {
        [EnableCors(origins: "http://localhost:5901", headers: "*", methods: "*")]
        // GET api/values  
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    /*
        Enable CORS in WebAPI 1.0
        If you are working in WebAPI 1.0 then you need to add the following code in Global.asax file. Here we enabled CORS in Application_BeginRequest() event which 
        checks origin name and then add headers to response object.
        
        protected void Application_BeginRequest()
        {
             string[] allowedOrigin = new string[] { "http://localhost:2051", "http://localhost:2052" };
             var origin = HttpContext.Current.Request.Headers["Origin"];
             if (origin != null && allowedOrigin.Contains(origin))
             {
                 HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin);
                 HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET,POST");
             }
        }
        
        Disable CORS
        Suppose you enabled CORS in Global or Controller level then all actions are enabled for CORS. However, if you want CORS  to not be enabled for couple of actions 
        due to some security reason, here DisableCors attribute plays vital role to Disable CORS which means other domains can't call the action.
        
        [DisableCors()]
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        
        CORS is mostly server-side technology which works tightly with browser. So CORS in browser support is also necessary. See what browsers are supported by CORS: 
        http://enable-cors.org/client.html
        
        Note
        {
            "Attempt by method 'System.Web.Http.GlobalConfiguration..cctor()' to access field 'System.Web.Http.GlobalConfiguration.CS$<>9__CachedAnonymousMethodDelegate2'
            failed."
        }
        
        Conclusion
        CORS is Cross Origin Request Sharing which enables you to call the methods of one domain from external domain. We discussed enabling CORS in two ways: 
        JSONP and Microsoft Cors package. Due to security reasons, browser incompatibility of Microsoft Cors wins over JSONP.
    */
}
