using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface IUserService : IService<ProfileDto>
    {
        Task<ResultDetails<Guid>> JoinToCourse(Guid profileId, Guid courseId);

        Task<ResultDetails<Guid>> LeaveCourse(Guid profileId, Guid courseId);

        Task<ResultDetails<Guid>> CompleteCourse(Guid profileId, Guid courseId);
        
        Task<ResultDetails<List<CourseDto>>> JoinedCourses(Guid profileId);

        Task<ResultDetails<List<CourseDto>>> CompletedCourses(Guid profileId);

        Task<ResultDetails<List<MaterialDto>>> LearnedMaterials(Guid profileId);

        Task<ResultDetails<List<ProfileSkillDto>>> ProfileSkills(Guid profileId);
    }
}
