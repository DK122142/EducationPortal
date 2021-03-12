using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.Interfaces
{
    public interface ISkillService : IService<SkillDto>
    {
        Task<Skill> GetSkillByName(string skillName);

        Task IncludeSkillInCourse(string skillId, string courseId);

        Task Add(IEnumerable<Skill> items);

        Task<int> Update(IEnumerable<Skill> items);
    }
}
