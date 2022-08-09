using AutoMapper;
using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesApp
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }
        public static void init()
        {
            var config = new MapperConfiguration(c =>
             {
                 c.CreateMap<Category, Categroiesmodel>()
                 .ForMember(dst=>dst.ParentId,src=>src.MapFrom(e=>e.Category2.ParentId))
                 .ForMember(dst => dst.ParentName,src=>src.MapFrom(e =>e.Category2.Name)).ReverseMap();
                 c.CreateMap<Trainer,TrainerModel>().ReverseMap();
                 c.CreateMap<Course, CourseModel>()
                 .ForMember(dts => dts.TrainerName, src => src.MapFrom(e => e.Trainer.Name))
                 .ForMember(dts => dts.CategoryName, src => src.MapFrom(e => e.Category.Name)).ReverseMap();
                 c.CreateMap<Trainee, TraineesModel>().ReverseMap();
                 c.CreateMap<TraineeCourse,TraineeCourseModel>()
                 .ForMember(dts =>dts.Trainees, src=>src.MapFrom(e=>e.Trainee))
                 .ReverseMap();

             });
            Mapper = config.CreateMapper();
        }
    }
}