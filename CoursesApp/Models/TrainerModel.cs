using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesApp.Models
{
    public class TrainerModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        public string Discription { get; set; }
        [Url(ErrorMessage ="Ivalid Website")]
        public string Website { get; set; }
        public System.DateTime creationDate { get; set; }
    }
}