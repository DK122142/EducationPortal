using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EducationPortal.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task SaveChangesAsync();

        Task<T> FirstOrDefaultAsync();

        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        ValueTask<T> FindAsync(params object[] keys);

        ValueTask<EntityEntry<T>> AddAsync(T entity);

        Task AddAsync(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        void Update(T entity);

        IOrderedQueryable<T> OrderBy<K>(Expression<Func<T, K>> predicate);

        IQueryable<IGrouping<K, T>> GroupBy<K>(Expression<Func<T, K>> predicate);

        Task<List<T>> SkipTakeToListAsync(int skip, int take);

        Task<int> CountAsync();
    }
}
