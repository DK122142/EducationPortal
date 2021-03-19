using System;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface IMaterialService : IService<MaterialDto>
    {
        Task<ResultDetails<Guid>> Create(Guid creatorId, MaterialDto material);

        Task<ResultDetails<Guid>> Edit(MaterialDto material);
    }
}
