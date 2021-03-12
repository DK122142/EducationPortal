using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task Add(T entity);

        Task Add(IEnumerable<T> items);
        
        Task<IList<T>> All();

        Task<T> GetById(string id);

        void Update(T entity);

        void Update(IEnumerable<T> items);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<T> Single(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetPage(int skip, int take);

        Task<int> TotalCount();

        IQueryable<T> AsNoTracking();
    }
}
