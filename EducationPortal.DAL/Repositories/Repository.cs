using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationPortal.DAL.DbContexts;
using EducationPortal.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbSet<T> table;
        private DbContext context;

        public Repository(EducationPortalContext context)
        {
            this.table = context.Set<T>();
            this.context = context;
        }

        public async Task Add(T entity) => await this.table.AddAsync(entity);

        public async Task Add(IEnumerable<T> items) => await this.table.AddRangeAsync(items);

        public async Task<IList<T>> All() => await this.table.AsNoTracking().ToListAsync();

        public async Task<T> GetById(string id) => await this.table.SingleAsync(x => x.Id.Equals(id));

        public void Update(T entity) => this.table.Update(entity);

        public void Update(IEnumerable<T> items) => this.table.UpdateRange(items);

        public void Delete(T entity) => this.table.Remove(entity);

        public void Delete(IEnumerable<T> entities) => this.table.RemoveRange(entities);

        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => this.table.Where(expression);

        public async Task<T> Single(Expression<Func<T, bool>> expression) => await this.table.SingleAsync(expression);
        
        public async Task<bool> Any(Expression<Func<T, bool>> expression) => await this.table.AnyAsync(expression);

        public async Task<IEnumerable<T>> GetPage(int skip, int take) =>
            await this.table.OrderBy(e => e.Id).Skip(skip).Take(take).ToListAsync();
        
        public async Task<int> TotalCount() => await this.table.CountAsync();

        public IQueryable<T> AsNoTracking() => this.table.AsNoTracking();
        
        public async Task<int> Commit() => await this.context.SaveChangesAsync();
    }
}
