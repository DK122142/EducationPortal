using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.BLL.Interfaces
{
    public interface IMaterialService<TMaterialDTO>
    {
        Task Add(TMaterialDTO material);

        IEnumerable<TMaterialDTO> GetAll();

        TMaterialDTO GetById(Guid id);

        IEnumerable<TMaterialDTO> Find(Func<TMaterialDTO, Boolean> predicate);
        
        Task Update(TMaterialDTO material);

        void Delete(Guid id);
    }
}
