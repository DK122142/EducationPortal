using EducationPortal.DAL.Entities;

namespace EducationPortal.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository<Entity>;

        IRepository<TEntity> GetRepositoryOfEntity<TEntity>() where TEntity : Entity;
    }
}
