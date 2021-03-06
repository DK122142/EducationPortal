using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationPortal.DAL.EF;
using EducationPortal.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> table;

        public Repository(EducationPortalContext context)
        {
            this.table = context.Set<T>();
        }

        public async Task Add(T entity) => await this.table.AddAsync(entity);

        public async Task Add(IEnumerable<T> items) => await this.table.AddRangeAsync(items);

        public async Task<IList<T>> All() => await this.table.AsNoTracking().ToListAsync();

        public async Task<T> GetById(string id) => await this.table.FindAsync(id);

        public void Update(T entity) => this.table.Update(entity);

        public void Update(IEnumerable<T> items) => this.table.UpdateRange(items);

        public void Delete(T entity) => this.table.Remove(entity);

        public void Delete(IEnumerable<T> entities) => this.table.RemoveRange(entities);

        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => this.table.Where(expression);
    }
}
