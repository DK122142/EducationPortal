using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
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

            CreateMap<ProfileSkillDto, ProfileSkillModel>().ReverseMap();
        }
    }
}
