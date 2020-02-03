using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace LearnApi.Controllers
{
    /*
        As you have seen in the Data Formats section that Web API handles JSON and XML formats based on Accept and Content-Type headers. But, how does it handle these
        different formats? The answer is: By using Media-Type formatters.

        Media type formatters are classes responsible for serializing request/response data so that Web API can understand the request data format and send data in the
        format which client expects.

        Web API includes following built-in media type formatters.

        Media Type Formatter Class                      MIME Type                               Description
        JsonMediaTypeFormatter                  application/json, text/json                 Handles JSON format.
        XmlMediaTypeFormatter                   application/xml, text/json                  Handles XML format.
        FormUrlEncodedMediaTypeFormatter        application/x-www-form-urlencoded           Handles HTML form URL-encoded data.
        JQueryMvcFormUrlEncodedFormatter        application/x-www-form-urlencoded           Handles model-bound HTML form URL-encoded data.
    */

    public class MediaTypeFormattersController : ApiController
    {
        public IEnumerable<string> Get()
        {
            /*
                Retrieve Built-in Media Type Formatters
                As mentioned above, Web API includes above listed media type formatter classes by default. However, you can also add, remove or change the order of
                formatters.
                
                The following example demonstrates HTTP GET method that returns all built-in formatter classes.
            */

            IList<string> formatters = new List<string>();
            foreach (var item in GlobalConfiguration.Configuration.Formatters)
            {
                formatters.Add(item.ToString());
            }
            return formatters.AsEnumerable<string>();

            /*
                In the above example, GlobalConfiguration.Configuration.Formatters returns MediaTypeFormatterCollection that includes all the formatter classes.
                The above example returns names of all the formatter classes as shown below.

                Below is the output:
                [
                    "System.Net.Http.Formatting.JsonMediaTypeFormatter",
                    "System.Net.Http.Formatting.XmlMediaTypeFormatter",
                    "System.Net.Http.Formatting.FormUrlEncodedMediaTypeFormatter",
                    "System.Web.Http.ModelBinding.JQueryMvcFormUrlEncodedFormatter"
                ]
            */
        }

        public IEnumerable<string> GetVs()
        {
            /*
                Alternatively, MediaTypeFormatterCollection class defines convenience properties that provide direct access to three of the four built-in media type
                formatters. The following example demonstrates retrieving media type formatters using MediaTypeFormatterCollection's properties.
            */

            IList<string> formatters = new List<string>();
            formatters.Add(GlobalConfiguration.Configuration.Formatters.JsonFormatter.GetType().FullName);
            formatters.Add(GlobalConfiguration.Configuration.Formatters.XmlFormatter.GetType().FullName);
            formatters.Add(GlobalConfiguration.Configuration.Formatters.FormUrlEncodedFormatter.GetType().FullName);
            return formatters.AsEnumerable<string>();

            /*
                Below is the output:
                [
                    "System.Net.Http.Formatting.JsonMediaTypeFormatter",
                    "System.Net.Http.Formatting.XmlMediaTypeFormatter",
                    "System.Net.Http.Formatting.FormUrlEncodedMediaTypeFormatter"
                ]
            */
        }

        /*
            BSON Formatter
            Web API also supports BSON format. As the name suggests, BSON is binary JSON, it is a binary-encoded serialization of JSON-like documents. Currently,
            there is very little support for BSON and no Javascript implementation is available for clients running in browsers. This means that it is not possible
            to retrieve and automatically parse BSON data to Javascript objects.

            Web API includes built-in formatter class BsonMediaTypeFormatter for BSON but it is disabled by default.
        */

        /*
            JSON Formatter
            As mentioned above, Web API includes JsonMediaTypeFormatter class that handles JSON format. The JsonMediaTypeFormatter converts JSON data in an HTTP
            request into CLR objects (object in C# or VB.NET) and also converts CLR objects into JSON format that is embeded within HTTP response.

            Internally, JsonMediaTypeFormatter use third-party open source library called Json.NET to perform serialization.
        */
    }

    /*
        Configure JSON Serialization
        JSON formatter can be configured in WebApiConfig class. The JsonMediaTypeFormatter class includes various properties and methods using which you can
        customize JSON serialization. For example, Web API writes JSON property names with PascalCase by default. To write JSON property names with cameCase,
        set the CamelCasePropertyNamesContractResolver on the serializer settings as shown below:
    */

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }

    /*
        XML Formatter
        The XmlMediaTypeFormatter class is responsible for serializing model objects into XML data. It uses System.Runtime.DataContractSerializer class to generate
        XML data.
    */
}
