using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;

namespace EducationPortal.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task Create(TEntity item);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task Update(TEntity item);

        void Delete(Guid id);
    }
}
