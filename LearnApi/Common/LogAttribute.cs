﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LearnApi.Common
{
    /*
        LogAttribute is derived from ActionFilterAttribute class and overrided OnActionExecuting and OnActionExecuted methods to log in the trace listeners.
    */
    public class LogAttribute : ActionFilterAttribute
    {
        public LogAttribute()
        {

        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Trace.WriteLine(string.Format("Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Trace.WriteLine(string.Format("Action Method {0} executing at {1}", actionExecutedContext.ActionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
        }
    }

    /*
        Another way of creating LogAttribute class is by implementing IActioinFilter interface and deriving Attribute class as shown below.
    */
    public class LogsAttribute : Attribute, IActionFilter
    {
        public LogsAttribute()
        {

        }

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Trace.WriteLine(string.Format("Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
            var result = continuation();
            result.Wait();
            Trace.WriteLine(string.Format("Action Method {0} executed at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
            return result;
        }

        public bool AllowMultiple
        {
            get
            {
                return true;
            }
        }
    }
    /*
        In the above example, deriving from Attribute class makes it an attribute and implementing IActionFilter makes LogAttribute class as action filter. So now,
        you can apply [Log] attributes on controllers or action methods.
    */
}