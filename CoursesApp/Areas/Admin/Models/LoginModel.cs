using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesApp.Areas.Admin.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        public string  Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Message { get; set; }


    }
}