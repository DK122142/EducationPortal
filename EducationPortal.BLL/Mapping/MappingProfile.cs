using System.Linq;
using EducationPortal.BLL.DTO;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>()
                .ForMember(a => a.Login, c => c.MapFrom(a => a.UserName))
                .ForMember(a => a.ProfileId, c => c.MapFrom(a => a.Profile.Id))
                .ReverseMap();

            CreateMap<Material, MaterialDto>()
                .Include<Article, ArticleDto>()
                .Include<Book, BookDTO>()
                .Include<Video, VideoDto>()
                .ForMember(m => m.OwnerId, c => c.MapFrom(m => m.AddedBy.Id))
                .ReverseMap();

            CreateMap<Course, CourseDto>()
                .ForMember(c => c.CreatorId, conf => conf.MapFrom(c => c.Creator.Id))
                .ForMember(c => c.MaterialNames, conf => conf.MapFrom(c => c.Materials.Select(m => m.Name)))
                .ForMember(c => c.SkillNames, conf => conf.MapFrom(c => c.Skills.Select(s => s.Name)))
                .ReverseMap();

            CreateMap<Profile, ProfileDto>()
                .ForMember(p => p.AccountUserName, c => c.MapFrom(p => p.Account.UserName))
                .ReverseMap();

            CreateMap<Skill, SkillDto>();

            CreateMap<Article, ArticleDto>()
                .ForMember(a => a.Published, c => c.MapFrom(a => a.Published.ToString()))
                .ReverseMap();

            CreateMap<Book, BookDTO>().ReverseMap();

            CreateMap<Video, VideoDto>().ReverseMap();

            CreateMap<ProfileSkill, ProfileSkillDto>()
                .ForMember(ps => ps.SkillName, c => c.MapFrom(ps => ps.Skill.Name));
        }
    }
}
