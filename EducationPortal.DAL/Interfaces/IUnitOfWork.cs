using System;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> Repository { get; }

        Task Commit();
    }
}
