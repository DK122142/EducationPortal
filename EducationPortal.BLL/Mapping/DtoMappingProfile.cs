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
                .ForMember(p => p.ProfileSkillsId, c => c.MapFrom(p => p.ProfileSkills.Select(ps => ps.SkillId)))
                .ForMember(p => p.AddedMaterialsId, c => c.MapFrom(p => p.AddedMaterials.Select(m => m.Id)))
                .ForMember(p => p.PassedMaterialsId, c => c.MapFrom(p => p.PassedMaterials.Select(m => m.Id)))
                .ForMember(p => p.CreatedCoursesId, o => o.MapFrom(p => p.CreatedCourses.Select(c => c.Id)))
                .ForMember(p => p.CompletedCoursesId, o => o.MapFrom(p => p.CompletedCourses.Select(c => c.Id)))
                .ForMember(p => p.JoinedCoursesId, o => o.MapFrom(p => p.JoinedCourses.Select(c => c.Id)))
                .ReverseMap();

            CreateMap<Material, MaterialDto>()
                .ForMember(m => m.AddedById, c => c.MapFrom(m => m.AddedBy.Id))
                .ForMember(m => m.PassedByUsersId, c => c.MapFrom(m => m.PassedByUsers.Select(p => p.Id)))
                .ForMember(m => m.IncludedInCoursesId, c => c.MapFrom(m => m.IncludedInCourses.Select(crs => crs.Id)))
                .Include<Article, ArticleDto>()
                .Include<Book, BookDto>()
                .Include<Video, VideoDto>()
                .ReverseMap();
            
            CreateMap<Article, ArticleDto>()
                .ForMember(a => a.Published, c => c.MapFrom(a => a.Published.ToShortDateString()))
                .ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<Video, VideoDto>().ReverseMap();

            CreateMap<Course, CourseDto>()
                .ForMember(c => c.CreatorId, conf => conf.MapFrom(c => c.Creator.Id))
                .ForMember(c => c.MaterialsId, conf => conf.MapFrom(c => c.Materials.Select(m => m.Id)))
                .ForMember(c => c.SkillsId, conf => conf.MapFrom(c => c.Skills.Select(s => s.Id)))
                .ForMember(c => c.JoinedProfilesId, o => o.MapFrom(c => c.JoinedProfiles.Select(p => p.Id)))
                .ForMember(c => c.CompletedProfilesId, o => o.MapFrom(c => c.CompletedProfiles.Select(p => p.Id)))
                .ReverseMap();

            CreateMap<Skill, SkillDto>()
                .ForMember(s => s.ProfileSkillsId, c => c.MapFrom(ps => ps.ProfileSkills.Select(sk => sk.ProfileId)))
                .ForMember(s => s.CoursesId, c => c.MapFrom(s => s.Courses.Select(crs => crs.Id)))
                .ReverseMap();

            CreateMap<ProfileSkill, ProfileSkillDto>().ReverseMap();
        }
    }
}
