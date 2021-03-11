using System;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IEntity;

        Task<int> Commit();
    }
}
