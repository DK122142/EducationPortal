using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface IUserService : IService<ProfileDto>
    {
        Task<ResultDetails> JoinToCourse(Guid profileId, Guid courseId);

        Task<ResultDetails> LeaveCourse(Guid profileId, Guid courseId);

        Task<ResultDetails> CompleteCourse(Guid profileId, Guid courseId);
        
        Task<ResultDetails<List<CourseDto>>> JoinedCourses(Guid profileId);

        Task<ResultDetails<List<CourseDto>>> CompletedCourses(Guid profileId);

        Task<ResultDetails<List<MaterialDto>>> LearnedMaterials(Guid profileId);

        Task<ResultDetails<List<ProfileSkillDto>>> ProfileSkills(Guid profileId);
    }
}
