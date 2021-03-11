using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationPortal.BLL.Interfaces
{
    public interface IService<TDto> where TDto : class
    {
        Task Add(TDto entity);

        Task Add(IEnumerable<TDto> items);
        
        Task<IList<TDto>> All();

        Task<TDto> GetById(string id);

        Task Update(TDto entity);

        Task Update(IEnumerable<TDto> items);

        void Delete(TDto entity);

        void Delete(IEnumerable<TDto> entities);

        IQueryable<TDto> Where(Expression<Func<TDto, bool>> expression);

        Task<IEnumerable<TDto>> GetPage(int skip, int take);

        Task<int> TotalCount();
    }
}
