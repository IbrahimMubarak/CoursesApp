using AutoMapper;
using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Areas.Admin.Controllers
{
    public class TrainersController : Controller
    {
        Courses_DBEntities ctx;
        IMapper Mapper;
 
        public TrainersController()
        {
            ctx = new Courses_DBEntities();
            Mapper = AutoMapperConfig.Mapper;
         
        }
        // GET: Admin/Trainers
        public ActionResult Index()
        {
            var trainers = ctx.Trainers.ToList();
            var trainerList =new List<TrainerModel>();
            foreach (var item in trainers)
            {
                trainerList.Add(new TrainerModel
                {
                    Id = item.Id,
                    Name=item.Name,
                    Email=item.Email,
                    Website=item.Website,
                    creationDate=item.creationDate,
                    Discription=item.Discription
                });
            }
            return View(trainerList);
        }

        // GET: Admin/Trainers/Details/5
        public ActionResult Details(int id)
        {
            var trainer = ctx.Trainers.Where(t => t.Id == id).FirstOrDefault();
            var model = new TrainerModel
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Email = trainer.Email,
                Website = trainer.Website,
                creationDate = trainer.creationDate,
                Discription = trainer.Discription
            };
            return View(model);
        }

        // GET: Admin/Trainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trainers/Create
        [HttpPost]
        public ActionResult Create(TrainerModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var isexist = ctx.Trainers.Where(t => t.Email.ToLower() == model.Email.ToLower()).FirstOrDefault();
                if (isexist != null)
                {
                    ViewBag.message = "email is exist alreay!!";
                    return View(model);
                }
                ctx.Trainers.Add(new Trainer
                {
                    Id = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Website = model.Website,
                    creationDate = DateTime.Now,
                    Discription = model.Discription
                });
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.message = "Error";
                return View(model);
            }
                
        }

        // GET: Admin/Trainers/Edit/5
        public ActionResult Edit(int id)
        {
            var trainer = ctx.Trainers.Where(t => t.Id == id).FirstOrDefault();
            var trainermodel = new TrainerModel
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Email = trainer.Email,
                Website = trainer.Website,
                creationDate = trainer.creationDate,
                Discription = trainer.Discription
            };

            return View(trainermodel);
        }

        // POST: Admin/Trainers/Edit/5
        [HttpPost]
        public ActionResult Edit(TrainerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
          

            ctx.Entry(new Trainer
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Website = model.Website,
                creationDate=model.creationDate,
                Discription = model.Discription
            }).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Trainers/Delete/5
        public ActionResult Delete(int id)
        {
            var trainer = ctx.Trainers.Where(t => t.Id == id).FirstOrDefault();
            var model = new TrainerModel
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Email = trainer.Email,
                Website = trainer.Website,
                creationDate = trainer.creationDate,
                Discription = trainer.Discription
            };
            return View(model);
        }

        // POST: Admin/Trainers/Delete/5
        [HttpPost]
        public ActionResult Deletepost(int id)
        {
                var trainer = ctx.Trainers.Where(t => t.Id == id).FirstOrDefault();
            ctx.Trainers.Remove(trainer);
            ctx.SaveChanges();
            return RedirectToAction("Index");
                 
               
        }

        public ActionResult TrainerCourses(int id)
        {
            var courses = ctx.Courses.Where(e =>e.Trainer.Id==id).ToList();
            var model=Mapper.Map<IEnumerable<CourseModel>>(courses);
            return View(model);  
        }
    }
}
