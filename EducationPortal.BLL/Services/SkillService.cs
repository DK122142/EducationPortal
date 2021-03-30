using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class SkillService : Service<Skill, SkillDto>, ISkillService
    {
        public SkillService(IRepository<Skill> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ResultDetails> Create(SkillDto item)
        {
            try
            {
                var entity = this.mapper.Map<Skill>(item);

                await this.repository.AddAsync(entity);

                await this.repository.SaveChangesAsync();

                return new ResultDetails(true);
            }
            catch
            {
                return new ResultDetails(false);
            }
        }
        
        public async Task<ResultDetails> Edit(SkillDto skill)
        {
            try
            {
                var entity = this.mapper.Map<Skill>(skill);

                this.repository.Update(entity);

                await this.repository.SaveChangesAsync();

                return new ResultDetails(true);
            }
            catch
            {
                return new ResultDetails(false);
            }
        }
    }
}
