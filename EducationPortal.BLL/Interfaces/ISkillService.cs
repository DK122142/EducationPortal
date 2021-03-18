using System.Threading.Tasks;
using EducationPortal.BLL.DTO;

namespace EducationPortal.BLL.Interfaces
{
    public interface ISkillService : IService<SkillDto>
    {
        Task Create(SkillDto item);

        Task Edit(SkillDto skill);
    }
}
