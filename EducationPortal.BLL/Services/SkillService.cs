using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.BLL.Services
{
    public class SkillService : Service<Skill, SkillDto>, ISkillService
    {
        public SkillService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public async Task<Skill> GetSkillByName(string skillName)
        {
            return await this.repository.Single(s => s.Name.Equals(skillName));
        }

        public async Task IncludeSkillInCourse(string skillId, string courseId)
        {
            var skill = await this.GetById(skillId);

            if (skill.CoursesId == null)
            {
                skill.CoursesId = new List<string>();
            }

            var included = skill.CoursesId.ToList();
            included.Add(courseId);

            skill.CoursesId = included;

            await this.Update(skill);

            return;
        }

        public Task Add(IEnumerable<Skill> items)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Update(IEnumerable<Skill> items)
        {
            this.repository.Update(items);
            return await this.uow.Commit();
        }
    }
}
