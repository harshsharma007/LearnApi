using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Understanding
{
    public class IdempotentController : ApiController
    {
        /*
            In the context of REST APIs, when making multiple identical requests has the same effect as making a single request - then that REST API is called idempotent.
            
            When you design REST APIs, you must realize that API consumers can make mistakes. Users can write client code in such a way that there can be duplicate
            requests coming to the API.
            
            These duplicate requests may be unintentional as well as intentional some time (e.g. due to timeout or network issues). You have to design fault-tolerant
            APIs in such a way that duplicate requests do not leave the system unstable.
            
            "An idempotent HTTP method is an HTTP method that can be called many times without different outcomes. It would not matter if the method is called only once,
            or ten times over. The result should be the same.
            
            Idempotence essentially means that the result of a successfully performed request is independent of the number of times it is executed. For example, in
            arithmetic, adding zero to a number is an idempotent operation."
            
            Idemotency with HTTP Methods
            If you follow REST principles in designing API, you will have automatically idempotent REST APIs for GET, PUT, DELETE, HEAD, OPTIONS and TRACE HTTP methods.
            Only POST APIs will not be idempotent.
            
            1. POST is NOT idempotent.
            2. GET, PUT, DELETE, HEAD, OPTIONS and TRACE are idempotent.
            
            Let's analyze how the above HTTP methods end up being idempotent - and why POST is not.
            
            HTTP POST
            Generally - not necessarily - POST APIs are used to create a new resource on server. So when you invoke the same POST request N times, you will have N new
            resources on the server. So, POST is not idempotent.
            
            HTTP GET, HEAD, OPTIONS and TRACE
            GET, HEAD, OPTIONS and TRACE methods NEVER change the resource state on server. They are purely for retrieving the resource representation or meta data at
            that point of time. So invoking multiple requests will not have any write operation on server, so GET, HEAD, OPTIONS and TRACE are idempotent.
            
            HTTP PUT
            Generally – not necessarily – PUT APIs are used to update the resource state. If you invoke a PUT API N times, the very first request will update the 
            resource; then rest N-1 requests will just overwrite the same resource state again and again – effectively not changing anything. Hence, PUT is idempotent.
            
            HTTP DELETE
            When you invoke N similar DELETE requests, first request will delete the resource and response will be 200 (OK) or 204 (No Content). Other N-1 requests will 
            return 404 (Not Found). Clearly, the response is different from first request, but there is no change of state for any resource on server side because 
            original resource is already deleted. So, DELETE is idempotent.

            Please keep in mind if some systems may have DELETE APIs like this:
            DELETE /item/last
            
            In the above case, calling operation N times will delete N resources – hence DELETE is not idempotent in this case. In this case, a good suggestion might be 
            to change the above API to POST – because POST is not idempotent.
            
            POST /item/last
            
            Now, this is closer to HTTP spec – hence more REST compliant.
        */
    }
}
