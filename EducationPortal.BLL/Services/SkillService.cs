using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class SkillService : Service<Skill, SkillDto>, ISkillService
    {
        protected SkillService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
