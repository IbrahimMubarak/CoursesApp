using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        Courses_DBEntities ctx;
        public DashboardController()
        {
            ctx = new Courses_DBEntities();
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Categories()
        {
            var cat = ctx.Categories.ToList();
            return View();
        }
    }
}