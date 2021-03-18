using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.Interfaces
{
    public interface IMaterialService : IService<MaterialDto>
    {
        Task Create(Guid creatorId, MaterialDto material);

        Task Edit(MaterialDto material);
    }
}
