using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.BLL.Interfaces
{
    public interface IMaterialService<TMaterialDTO>
    {
        Task AddMaterial(TMaterialDTO material);

        IEnumerable<TMaterialDTO> GetAllMaterials();

        TMaterialDTO GetMaterialById(Guid id);

        IEnumerable<TMaterialDTO> FindMaterial(Func<TMaterialDTO, Boolean> predicate);
        
        Task UpdateMaterial(TMaterialDTO material);

        void DeleteMaterial(Guid id);
    }
}
