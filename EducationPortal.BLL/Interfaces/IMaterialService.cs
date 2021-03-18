using System;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;

namespace EducationPortal.BLL.Interfaces
{
    public interface IMaterialService : IService<MaterialDto>
    {
        Task Create(Guid creatorId, MaterialDto material);

        Task Edit(MaterialDto material);
    }
}
