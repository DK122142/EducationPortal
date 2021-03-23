using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface ISkillService : IService<SkillDto>
    {
        Task<ResultDetails> Create(SkillDto item);

        Task<ResultDetails> Edit(SkillDto skill);
    }
}
