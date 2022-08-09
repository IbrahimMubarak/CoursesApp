using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoursesApp.Models;
namespace CoursesApp.Areas.Admin.Controllers
{
    
    public class CategroiesController : Controller
    {
        Courses_DBEntities ctx;
        public CategroiesController()
        {
            ctx = new Courses_DBEntities();
        }
        // GET: Admin/Categroies
        public ActionResult Index()
        {
            var cat = ctx.Categories.ToList();
            var catlist = new List<Categroiesmodel>();
            foreach (var item in cat)
            {
                catlist.Add(new Categroiesmodel {
                    Id = item.Id,
                    Name = item.Name,
                    ParentName=item.Category2?.Name
                
                });
            }
            return View(catlist);
        }

        // GET: Admin/Categroies/Details/5
        public ActionResult Details(int id)
        {
            var cat = ctx.Categories.Where(t => t.Id == id).FirstOrDefault();
            var model = new Categroiesmodel
            {
                Id = cat.Id,
                Name = cat.Name,
                ParentName = cat.Category2?.Name
            };
            return View(model);
            
        }

        // GET: Admin/Categroies/Create
        public ActionResult Create()
        {
            var categoryModel = new Categroiesmodel();
            intializeList(null,ref categoryModel);
            return View(categoryModel);
        }

        // POST: Admin/Categroies/Create
        [HttpPost]
        public ActionResult Create(Categroiesmodel cat)
        {
            if (!ModelState.IsValid)
            {
                intializeList(null,ref cat);
                return View(cat);
            }
            else
            {
                var isexist = ctx.Categories.Where(c => c.Name.ToLower() == cat.Name.ToLower()).Any();
                if(isexist)
                {
                    intializeList(null,ref cat);
                    ViewBag.message = "Duplicated Category";
                    return View(cat);
                }   
                else
                {

                    ctx.Categories.Add(new Category
                    {
                        Name = cat.Name,
                        ParentId = cat.ParentId
                        
                    });
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
        }
       
        // GET: Admin/Categroies/Edit/5
        public ActionResult Edit(int id)
        {
            
            var cat = ctx.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (cat == null)
            {
                return HttpNotFound("Not Found");
            }
            
            var catmodel = new Categroiesmodel {
                Id = cat.Id,
                Name=cat.Name,
                ParentId=cat.ParentId
            };
            intializeList(cat.Id, ref catmodel);
            return View(catmodel);
        }

        // POST: Admin/Categroies/Edit/5
        [HttpPost]
        public ActionResult Edit(Categroiesmodel cat)
        {
            if(!ModelState.IsValid)
            {
                intializeList(cat.Id,ref cat);
                return View(cat);
            }
            var isexist = ctx.Categories.Where(c => c.Name.ToLower() != cat.Name.ToLower());
            if (isexist.Where(c => c.Name.ToLower() == cat.Name.ToLower()).Any())
            {
                intializeList(cat.Id,ref cat);
                ViewBag.message1 = "Duplicated Category";
                return View(cat);
            }
            ctx.Entry(new Category
            {
                Id = cat.Id,
                Name=cat.Name,
                ParentId=cat.ParentId
                }).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

        // GET: Admin/Categroies/Delete/5
        public ActionResult Delete(int id)
        {
            if(id==0)
            {
                return RedirectToAction("Index", "Categroies");
            }
            var cat = ctx.Categories.Where(c => c.Id == id).FirstOrDefault();
            var categoryModel = new Categroiesmodel
            {
                Id = cat.Id,
                Name=cat.Name,
                ParentId=cat.ParentId,
                ParentName=cat.Category2?.Name
            };
            return View(categoryModel);
        }

        // POST: Admin/Categroies/Delete/5
        [HttpPost]
        public ActionResult DeleteCat(int? id)
        {   
            var cat = ctx.Categories.Where(c => c.Id == id).FirstOrDefault();
            
            if (cat != null)
            {
                try
                {
                    ctx.Categories.Remove(cat);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    var catogrymodel = new Categroiesmodel
                    {
                        Id = cat.Id,
                        Name = cat.Name,
                        ParentId = cat.ParentId,
                        ParentName = cat.Category2?.Name
                    };
                    ViewBag.message="Can't delete parent category!!";
                    return View("Delete", catogrymodel);
                }
            }
            return View();
        }
        //intialize dropdaownlist
        private void intializeList(int? currentcat,ref Categroiesmodel cat)
        {
            

            var catgs = ctx.Categories.ToList();
            if(currentcat!=null)
            {
                var current = ctx.Categories.Where(c => c.Id == currentcat).FirstOrDefault();
                catgs.Remove(current);
            }
            cat.list = new SelectList(catgs, "Id", "Name");
            
        }
    }
}
