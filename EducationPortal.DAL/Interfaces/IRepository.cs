using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T item);

        IEnumerable<T> GetAll();

        T Get(Guid id);

        IEnumerable<T> Find(Func<T, Boolean> predicate);

        Task Update(T item);

        void Delete(Guid id);
    }
}
