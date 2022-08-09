using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Models
{
    public class Categroiesmodel
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string ParentName { get; set; }
        public SelectList list { get; set; }
    }
}