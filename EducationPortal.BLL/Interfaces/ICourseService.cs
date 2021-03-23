using System;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface ICourseService : IService<CourseDto>
    {
        Task<ResultDetails> Create(Guid creatorId, CourseDto course);
        
        Task<ResultDetails> Edit(CourseDto course);
        
        Task<ResultDetails> AddSkillToCourse(Guid skillId, Guid courseId);

        Task<ResultDetails> AddMaterialToCourse(Guid materialId, Guid courseId);

        Task<ResultDetails> RemoveSkillFromCourse(Guid skillId, Guid courseId);

        Task<ResultDetails> RemoveMaterialFromCourse(Guid materialId, Guid courseId);
        
    }
}
