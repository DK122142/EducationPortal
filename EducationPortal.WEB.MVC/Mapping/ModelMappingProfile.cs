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
            CreateMap<CourseModel, CourseViewModel>().ReverseMap();
            
            CreateMap<SkillDto, SkillModel>().ReverseMap();
            CreateMap<SkillDto, SkillCreateViewModel>().ReverseMap();

            CreateMap<ProfileSkillDto, ProfileSkillModel>().ReverseMap();
        }
    }
}
