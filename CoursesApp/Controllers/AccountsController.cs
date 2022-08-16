using CoursesApp.Models;
using CoursesApp.Models.Landpage;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Controllers
{
    public class AccountsController : Controller
    {

        Courses_DBEntities ctx;
        public AccountsController()
        {
            ctx =new Courses_DBEntities();
        }
        // GET: Account
        public ActionResult Login()
        {
            
                return View();
        }
        [HttpPost]
        public ActionResult Login(GlobalLogModel log )
        {
            if (ModelState.IsValid)
            {
                if(ctx.Trainees.Where(e=>e.Email.ToLower()==log.Email.ToLower() &&e.Password==log.Password).Any())
                {
                    return RedirectToAction("index","Profile");
                }
                else
                {
                    log.Message = "Invalid email or password";
                    return View(log);
                }
            }
            else
            {
                log.Message = "Invalid data";
                return View(log);
            }
          
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(Register reg)
        {
            if (ModelState.IsValid)
            {
                var regtrainee = new Trainee
                {
                    Name = reg.Name,
                    Email = reg.Email,
                    Password = reg.Password,
                    CreationDate = DateTime.Now

                };
                ctx.Trainees.Add(regtrainee);
                ctx.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                reg.Message = "Invalid data";
                return View(reg);
            }
                
        }


    }
}
