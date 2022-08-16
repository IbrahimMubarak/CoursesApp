using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesApp.Models
{
    public class IdentityContext:IdentityDbContext<MyIdentityUser>
    {
        public IdentityContext():base("Courses_Connection")
        {

        }

        
    }

    public class MyIdentityUser:IdentityUser
    {

    }
}