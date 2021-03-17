using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationPortal.DAL.DbContexts;
using EducationPortal.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EducationPortal.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> table;
        private readonly DbContext context;

        public Repository(EducationPortalContext context)
        {
            this.context = context;
            this.table = context.Set<T>();
        }

        public Task<List<T>> SkipTakeToListAsync(int skip, int take)
        {
            return this.table.Skip(skip).Take(take).ToListAsync();
        }
        
        public Task<int> CountAsync()
        {
            return this.table.CountAsync();
        }

        public virtual Task SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }

        public virtual Task<T> FirstOrDefaultAsync()
        {
            return this.table.FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAll()
        {
            return this.table.AsNoTracking();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.table.Where(predicate);
        }

        public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return this.table.AnyAsync(predicate);
        }

        public virtual ValueTask<T> FindAsync(params object[] keys)
        {
            return this.table.FindAsync(keys);
        }

        public virtual ValueTask<EntityEntry<T>> AddAsync(T entity)
        {
            return this.table.AddAsync(entity);
        }

        public virtual Task AddAsync(IEnumerable<T> entities)
        {
            return this.table.AddRangeAsync(entities);
        }

        public virtual void Delete(T entity)
        {
            this.table.Remove(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            this.table.RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IOrderedQueryable<T> OrderBy<K>(Expression<Func<T, K>> predicate)
        {
            return this.table.OrderBy(predicate);
        }

        public virtual IQueryable<IGrouping<K, T>> GroupBy<K>(Expression<Func<T, K>> predicate)
        {
            return this.table.GroupBy(predicate);
        }
    }
}
