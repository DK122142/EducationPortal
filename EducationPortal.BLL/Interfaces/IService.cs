using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationPortal.BLL.Interfaces
{
    public interface IService<TDto>
        where TDto : class
    {
        Task<IEnumerable<TDto>> GetPage(int pageNumber, int itemsOnPage);

        Task<TDto> GetById(Guid id);
        
        IQueryable<TDto> FindBy(Expression<Func<TDto, bool>> predicate);

        Task Delete(Guid id);

        Task<int> TotalCountAsync();
    }
}
