using System;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;

namespace EducationPortal.BLL.Interfaces
{
    public interface ICourseService : IService<CourseDto>
    {
        Task Create(Guid creatorId, CourseDto course);
        
        Task Edit(CourseDto course);
        
        Task AddSkillToCourse(Guid skillId, Guid courseId);

        Task AddMaterialToCourse(Guid materialId, Guid courseId);
        
    }
}
