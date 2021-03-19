using System;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface ICourseService : IService<CourseDto>
    {
        Task<ResultDetails<Guid>> Create(Guid creatorId, CourseDto course);
        
        Task<ResultDetails<Guid>> Edit(CourseDto course);
        
        Task<ResultDetails<Guid>> AddSkillToCourse(Guid skillId, Guid courseId);

        Task<ResultDetails<Guid>> AddMaterialToCourse(Guid materialId, Guid courseId);

        Task<ResultDetails<Guid>> RemoveSkillFromCourse(Guid skillId, Guid courseId);

        Task<ResultDetails<Guid>> RemoveMaterialFromCourse(Guid materialId, Guid courseId);
        
    }
}
