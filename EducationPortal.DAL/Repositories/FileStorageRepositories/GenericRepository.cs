using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.DAL.FS.Interfaces;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IContext context;

        public GenericRepository(IEducationPortalContext context)
        {
            this.context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.context.Db.GetAll<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return this.context.Db.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return this.context.Db.Find(predicate);
        }

        public Task Create(TEntity item)
        {
            return this.context.Db.CreateAsync(item);
        }

        public Task Update(TEntity item)
        {
            return this.context.Db.UpdateAsync(item);
        }

        public void Delete(Guid id)
        {
            this.context.Db.Delete<TEntity>(id);
        }
    }
}
