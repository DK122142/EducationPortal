using System;
using System.Linq;
using AutoMapper;
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
            CreateMap<BookDto, BookModel>()
                .ForMember(b => b.Authors, c => c.MapFrom(b => string.Join(",", b.Authors)));
            CreateMap<VideoDto, VideoModel>().ReverseMap();

            CreateMap<BookModel, BookDto>()
                .ForMember(b => b.Authors,
                    c => c.MapFrom(b => b.Authors.Split(",", StringSplitOptions.TrimEntries).ToList()));

            CreateMap<MaterialDto, MaterialViewModel>()
                .Include<ArticleDto, ArticleCreateViewModel>()
                .Include<BookDto, BookCreateViewModel>()
                .Include<VideoDto, VideoCreateViewModel>()
                .ReverseMap();
            
            CreateMap<ArticleDto, ArticleCreateViewModel>().ReverseMap();
            CreateMap<BookDto, BookCreateViewModel>()
                .ForMember(b => b.Authors, c => c.MapFrom(b => string.Join(",", b.Authors)));
            CreateMap<VideoDto, VideoCreateViewModel>().ReverseMap();

            CreateMap<BookCreateViewModel, BookDto>()
                .ForMember(b => b.Authors,
                    c => c.MapFrom(b => b.Authors.Split(",", StringSplitOptions.TrimEntries).ToList()));
            
            CreateMap<CourseDto, CourseModel>().ReverseMap();
            CreateMap<CourseViewModel, CourseDto>()
                .ForMember(c => c.SkillsId, conf => conf.MapFrom(c => c.Skills.Select(s => s.Id)))
                .ForMember(c => c.MaterialsId, conf => conf.MapFrom(c => c.Materials.Select(m => m.Id)))
                .ReverseMap();
            CreateMap<CourseDto, CourseCreateViewModel>().ReverseMap();
            CreateMap<CourseContinueCreateViewModel, CourseDto>()
                .ForMember(c => c.SkillsId, conf => conf.MapFrom(c => c.Skills.Models.Select(s => s.Id)))
                .ForMember(c => c.MaterialsId, conf => conf.MapFrom(c => c.Materials.Models.Select(s => s.Id)))
                .ReverseMap();
            CreateMap<CourseModel, CourseCreateViewModel>().ReverseMap();
            CreateMap<CourseModel, CourseContinueCreateViewModel>().ReverseMap();
            
            CreateMap<SkillDto, SkillModel>().ReverseMap();
            CreateMap<SkillDto, SkillCreateViewModel>().ReverseMap();

            CreateMap<ProfileSkillDto, ProfileSkillModel>().ReverseMap();
        }
    }
}
