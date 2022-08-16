using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(CoursesApp.App_Start.Startup))]

namespace CoursesApp.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            CookieAuthenticationOptions CookieAuthOp = new CookieAuthenticationOptions();
            CookieAuthOp.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            CookieAuthOp.LoginPath =new PathString("~/Accounts/Login");
            app.UseCookieAuthentication(CookieAuthOp);
        }
    }
}
