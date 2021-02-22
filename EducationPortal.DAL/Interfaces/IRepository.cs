using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;

namespace EducationPortal.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task Create(TEntity item);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);

        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);

        Task Update(TEntity item);

        void Delete(Guid id);
    }
}
