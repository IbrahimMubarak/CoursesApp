using AutoMapper;
using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Areas.Admin.Views.Categroies
{
    public class TraineesController : Controller
    {
        // GET: Admin/Trainees
        Courses_DBEntities ctx;
        IMapper Mapper;
        public TraineesController()
        {
            ctx = new Courses_DBEntities();
            Mapper = AutoMapperConfig.Mapper;
        }
        public ActionResult Index(int id)
        {
            var trainees = ctx.TraineeCourses.Where(c => c.CourseId == id);
            var model = Mapper.Map<IEnumerable<TraineeCourseModel>>(trainees);
            ViewBag.coursename = ctx.Courses.Where(i => i.Id == id).FirstOrDefault();
            return View(model);
        }

        // GET: Admin/Trainees/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Trainees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trainees/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Trainees/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Trainees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Trainees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Trainees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
