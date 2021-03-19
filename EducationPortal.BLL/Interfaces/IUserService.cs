using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;

namespace EducationPortal.BLL.Interfaces
{
    public interface IUserService : IService<ProfileDto>
    {
        Task JoinToCourse(Guid profileId, Guid courseId);

        Task LeaveCourse(Guid profileId, Guid courseId);

        Task CompleteCourse(Guid profileId, Guid courseId);
        
        Task<List<CourseDto>> JoinedCourses(Guid profileId);

        Task<List<CourseDto>> CompletedCourses(Guid profileId);

        Task<List<MaterialDto>> LearnedMaterials(Guid profileId);

        Task<List<ProfileSkillDto>> ProfileSkills(Guid profileId);
    }
}
