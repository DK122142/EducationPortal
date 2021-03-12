using System.Linq;
using EducationPortal.BLL.DTO;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.Mapping
{
    public class DtoMappingProfile : AutoMapper.Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Account, AccountDto>()
                .ForMember(a => a.Login, c => c.MapFrom(a => a.UserName))
                .ForMember(a => a.ProfileId, c => c.MapFrom(a => a.Profile.Id))
                .ReverseMap();

            CreateMap<Profile, ProfileDto>()
                .ForMember(p => p.AccountUserName, c => c.MapFrom(p => p.Account.UserName))
                .ForMember(p=>p.JoinedCoursesNames,o=>o.MapFrom(p=>p.JoinedCourses.Select(c=>c.Name)))
                .ForMember(p=>p.CompletedCoursesNames,o=>o.MapFrom(p=>p.CompletedCourses.Select(c=>c.Name)))
                .ReverseMap();

            CreateMap<Material, MaterialDto>()
                .ForMember(m=>m.IncludedInId,c=>c.MapFrom(m=>m.IncludedIn.Select(crs=>crs.Id)))
                .ForMember(m=>m.PassedByUsersId,c=>c.MapFrom(m=>m.PassedByUsers.Select(p=>p.Id)))
                .Include<Article, ArticleDto>()
                .Include<Book, BookDto>()
                .Include<Video, VideoDto>()
                .ReverseMap();
            
            CreateMap<Article, ArticleDto>()
                .ForMember(a => a.Published, c => c.MapFrom(a => a.Published.ToString()))
                .ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<Video, VideoDto>().ReverseMap();

            CreateMap<Course, CourseDto>()
                .ForMember(c => c.MaterialNames, conf => conf.MapFrom(c => c.Materials.Select(m => m.Name)))
                .ForMember(c => c.SkillNames, conf => conf.MapFrom(c => c.Skills.Select(s => s.Name)))
                .ForMember(c=>c.JoinedProfilesId,o=>o.MapFrom(c=>c.JoinedProfiles.Select(p=>p.Id)))
                .ForMember(c=>c.CompletedProfilesId,o=>o.MapFrom(c=>c.CompletedProfiles.Select(p=>p.Id)))
                .ReverseMap();

            CreateMap<Skill, SkillDto>()
                .ForMember(s => s.CoursesId, c => c.MapFrom(s => s.Courses.Select(crs => crs.Id)))
                .ForMember(s => s.ProfileSkillsId, c => c.MapFrom(ps => ps.ProfileSkills.Select(sk => sk.Id)))
                .ReverseMap();


            CreateMap<ProfileSkill, ProfileSkillDto>()
                .ForMember(ps => ps.SkillName, c => c.MapFrom(ps => ps.Skill.Name))
                .ReverseMap();
        }
    }
}
