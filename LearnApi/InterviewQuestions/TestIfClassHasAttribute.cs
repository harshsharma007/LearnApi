using LearnApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnApi.InterviewQuestions
{
    [Log]
    public class TestIfClassHasAttribute
    {
        /*
            How would you determine if a Class has a particular attribute?
            
            I'm trying to do a little Test-First development and I'm trying to verify that my classes are marked with an attribute:
            
            [SubControllerActionToViewDataAttribute]
            public class ScheduleController : Controller
            
            How do I unit test that the class has that attribute assigned to it?
        */

        public TestIfClassHasAttribute()
        {
            Attribute.GetCustomAttribute(typeof(TestIfClassHasAttribute), typeof(LogAttribute));
        }
    }
}