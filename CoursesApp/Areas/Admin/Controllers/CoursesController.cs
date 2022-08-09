using AutoMapper;
using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {

        Courses_DBEntities ctx;
        IMapper Mapper;
        public CoursesController()
        {
            ctx = new Courses_DBEntities();
            Mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Courses
        public ActionResult Index()
        {
            var courses = ctx.Courses.ToList();
            var CourseModel = Mapper.Map<IEnumerable<CourseModel>>(courses);
            return View(CourseModel);
        }

        // GET: Admin/Courses/Details/5
        public ActionResult Details(int id)
        {
            var courses = ctx.Courses.Where(c => c.Id == id).FirstOrDefault();
            var CourseModel = Mapper.Map<CourseModel>(courses);
            return View(CourseModel);
        }

        // GET: Admin/Courses/Create
        public ActionResult Create()
        {
            CourseModel coursemodel = new CourseModel();
            intiatLists(ref coursemodel);
            return View(coursemodel);
        }

        // POST: Admin/Courses/Create
        [HttpPost]
        public ActionResult Create(CourseModel coursemodel)
        {
            intiatLists(ref coursemodel);
           
            try
            {
                if(ModelState.IsValid)
                {
                    coursemodel.ImgId = savingimg(coursemodel.ImgFile, coursemodel.ImgId);
                    
                    var course = Mapper.Map<Course>(coursemodel);
                    course.Category = null;
                    course.Trainer = null;
                    
                    course.CreationDate = DateTime.Now;
                    ctx.Courses.Add(course);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(coursemodel);
                
            }
            catch
            {
                ViewBag.message = "Error";
                return View(coursemodel);

            }
        }

        // GET: Admin/Courses/Edit/5
        public ActionResult Edit(int id)
        {
            var courses = ctx.Courses.Where(c => c.Id == id).FirstOrDefault();
            var CourseModel = Mapper.Map<CourseModel>(courses);
            intiatLists(ref CourseModel);
            return View(CourseModel);
        }

        // POST: Admin/Courses/Edit/5
        [HttpPost]
        public ActionResult Edit(CourseModel coursemodel)
        {
            intiatLists(ref coursemodel);
            try
            {
               
                if (ModelState.IsValid)
                {
                    coursemodel.ImgId = savingimg(coursemodel.ImgFile, coursemodel.ImgId);    
                    var course = Mapper.Map<Course>(coursemodel);
                    course.Category = null;
                    course.Trainer = null;
                    ctx.Entry(course).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                
                    
                    return View(coursemodel);
                
            }
            catch(Exception EX)
            {
                ViewBag.message = "Error";
                return View(coursemodel);

            }
        }

        // GET: Admin/Courses/Delete/5
        public ActionResult Delete(int id)
        {
            var courses = ctx.Courses.Where(c => c.Id == id).FirstOrDefault();
            var CourseModel = Mapper.Map<CourseModel>(courses);
            return View(CourseModel);
        }

        // POST: Admin/Courses/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == 0 || id == null)
                {
                    return RedirectToAction("Index");
                }
                var course = ctx.Courses.Where(c => c.Id == id).FirstOrDefault();
                ctx.Courses.Remove(course);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void intiatLists(ref CourseModel coursemodel)
        {
            var categrios = ctx.Categories.ToList();
            var mappedCategories = Mapper.Map<IEnumerable<Categroiesmodel>>(categrios);
            coursemodel.Categories = new SelectList(mappedCategories, "Id", "Name");
            var trainers = ctx.Trainers.ToList();
            var mappedTrainers = Mapper.Map<IEnumerable<TrainerModel>>(trainers);
            coursemodel.Trainers = new SelectList(mappedTrainers, "Id", "Name");
        }

        private string savingimg(HttpPostedFileBase img, string currentImgId)
        {
            if (img != null)
            {

                var ImgExtention = Path.GetExtension(img.FileName);
                var imgGuid = Guid.NewGuid().ToString();
                string ImgId = imgGuid + ImgExtention;
                //save img
                string savingpath = Server.MapPath($"~/Uploads/Courses/{ImgId}");
                img.SaveAs(savingpath);

                if (!string.IsNullOrEmpty(currentImgId))
                {
                    string oldfile = Server.MapPath($"~/Uploads/Courses/{currentImgId}");
                    System.IO.File.Delete(oldfile);
                }
                return ImgId;
            }
            return currentImgId;
        }
    }
}
