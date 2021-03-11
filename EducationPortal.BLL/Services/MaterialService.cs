using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class MaterialService : Service<Material, MaterialDto>, IMaterialService
    {
        public MaterialService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
