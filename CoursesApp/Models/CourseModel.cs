using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Required]
        [Display(Name ="Trainer")]
        public Nullable<int> TrainerId { get; set; }
        public string TrainerName { get; set; }
        [Display(Name = "Image")]
        public string ImgId { get; set; }
       
        public HttpPostedFileBase ImgFile { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Trainers { get; set; }
    }
}