using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationPortal.BLL.Interfaces
{
    public interface IService<TDto>
        where TDto : class
    {
        Task<IEnumerable<TDto>> GetPageAsync(int pageNumber, int itemsOnPage);

        Task<TDto> GetByIdAsync(Guid id);
        
        Task<IEnumerable<TDto>> FindBy(Expression<Func<TDto, bool>> predicate);

        Task DeleteAsync(Guid id);

        Task<int> TotalCountAsync();
    }
}
