using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;

namespace EducationPortal.BLL.Interfaces
{
    public interface IMaterialService<TMaterialDTO> where TMaterialDTO : MaterialDTO
    {
        Task Add(TMaterialDTO material);

        IEnumerable<TMaterialDTO> GetAll();

        TMaterialDTO GetById(Guid id);

        IEnumerable<TMaterialDTO> Find(Expression<Func<TMaterialDTO, bool>> predicate);
        
        Task Update(TMaterialDTO material);

        void Delete(Guid id);
    }
}
