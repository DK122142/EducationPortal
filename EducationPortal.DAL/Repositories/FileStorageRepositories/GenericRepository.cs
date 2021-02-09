using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private FSContext context;

        public GenericRepository(FSContext context)
        {
            this.context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.context.Storage.GetAll<TEntity>();
        }

        public TEntity Get(Guid id)
        {
            return this.context.Storage.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return this.context.Storage.Find(predicate);
        }

        public Task Create(TEntity item)
        {
            return this.context.Storage.CreateAsync(item);
        }

        public Task Update(TEntity item)
        {
            return this.context.Storage.UpdateAsync(item);
        }

        public void Delete(Guid id)
        {
            this.context.Storage.Delete<TEntity>(id);
        }
    }
}
