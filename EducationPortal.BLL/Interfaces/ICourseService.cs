using System;
using System.Linq;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;

namespace EducationPortal.BLL.Interfaces
{
    public interface ICourseService : IService<CourseDto>
    {
        Task<Guid> Create(Guid creatorId, CourseDto course);
        
        Task Edit(CourseDto course);
        
        IQueryable<SkillDto> SearchSkill(string searchString);

        void SearchMaterial(string searchString);
    }
}
