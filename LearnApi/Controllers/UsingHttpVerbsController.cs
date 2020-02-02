using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers
{
    /*
        Web Api controller characteristics
        1. It must be derived from System.Web.Http.ApiController class.
        2. It can be created under any folder in the project's root folder. However, it is recommended to create controller classes in the Controllers folder
        as per the convention.
        3. Action method name can be the same as HTTP verb name or it can start with HTTP verb with any suffix (case in-sensitive) or you can apply HTTP verb
        attributes to method.
        4. Return type of an action method can be any primitive or complex type.
    */
    public class UsingHttpVerbsController : ApiController
    {
        [HttpGet]
        public List<string> Values()
        {
            return new List<string>() { "Harsh", "Sharma" };
        }

        [HttpGet]
        public string Value(int id)
        {
            return "Harsh";
        }

        [HttpPost]
        public void SaveNewValues([FromBody]string Value)
        {
            //Logic
        }

        [HttpPut]
        public void UpdateValue(int id, [FromBody]string Value)
        {
            //Logic
        }

        [HttpDelete]
        public void RemoveValue(int id)
        {
            //Logic
        }
    }

    /*
        Naming convention of a web method.
    
        HTTP Method           Possible Web Api Action Method Name             Usage
        GET                   Get()                                           Retrieves Data
                              get()
                              GET()
                              GetAllStudents()
                              *any name starting with Get*
        
        POST                  Post()                                          Inserts new record
                              post()
                              POST()
                              PostNewStudent()
                              *any name starting with Post*

        PUT                   Put()                                           Updates existing record
                              put()
                              PUT()
                              PutStudent()
                              *any name starting with Put*

        PATCH                 Patch()                                         Updates record partially
                              patch()
                              PATCH()
                              PatchStudent()
                              *any name starting with Patch*

        DELETE                Delete()                                        Deletes record
                              delete()
                              DELETE()
                              DeleteStudent()
                              *any name starting with Delete*
    */
}
