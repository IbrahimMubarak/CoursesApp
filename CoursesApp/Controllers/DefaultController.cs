using AutoMapper;
using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Controllers
{
    public class DefaultController : Controller
    {
        IMapper mapper;
        Courses_DBEntities ctx;

        public DefaultController()
        {
            mapper = AutoMapperConfig.Mapper;
            ctx = new Courses_DBEntities();
        }
        // GET: Default
        public ActionResult Index()
        {
            var courses = ctx.Courses.ToList();
            var coursesModel = mapper.Map<IEnumerable<CourseModel>>(courses);
            return View(coursesModel);
        }
    }
}