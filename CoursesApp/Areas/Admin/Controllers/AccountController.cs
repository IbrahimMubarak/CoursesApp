using CoursesApp.Areas.Admin.Models;
using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CoursesApp.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        Courses_DBEntities ctx;
        public AccountController()
        {
            ctx = new Courses_DBEntities();
        }
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login); 
            }
            var admin = ctx.Admins.Where(a => a.Email.ToLower() == login.Email.ToLower() && a.Password == login.Password).FirstOrDefault();
            if (admin != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                login.Message = "Email or Passwod is incorrect!";
                return View(login);

            }
        }



    }
}