using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesApp.Models
{
    public class TraineeCourseModel
    {
        public int CourseId { get; set; }
        public System.DateTime RegistirationDate { get; set; }
        public Trainee Trainees { get; set; }
    }
}