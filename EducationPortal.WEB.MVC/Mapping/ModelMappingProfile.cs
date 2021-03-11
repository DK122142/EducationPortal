﻿using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.WEB.MVC.Models;
using EducationPortal.WEB.MVC.ViewModels;

namespace EducationPortal.WEB.MVC.Mapping
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<ProfileDto, ProfileModel>().ReverseMap();

            CreateMap<MaterialDto, MaterialModel>()
                .Include<ArticleDto, ArticleModel>()
                .Include<BookDto, BookModel>()
                .Include<VideoDto, VideoModel>()
                .ReverseMap();
            
            CreateMap<ArticleDto, ArticleModel>().ReverseMap();
            CreateMap<BookDto, BookModel>().ReverseMap();
            CreateMap<VideoDto, VideoModel>().ReverseMap();

            CreateMap<CourseDto, CourseModel>().ReverseMap();
            
            CreateMap<SkillDto, SkillModel>().ReverseMap();
            CreateMap<SkillDto, SkillViewModel>().ReverseMap();

            CreateMap<ProfileSkillDto, ProfileSkillModel>().ReverseMap();
        }
    }
}
