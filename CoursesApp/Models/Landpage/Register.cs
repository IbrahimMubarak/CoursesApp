using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoursesApp.Models.Landpage
{
    public class Register
    {
        [Required]
        [StringLength(50,MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }

    }
}