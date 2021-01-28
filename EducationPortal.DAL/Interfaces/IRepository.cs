using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Guid id);

        IEnumerable<T> Find(Func<T, Boolean> predicate);

        Task Create(T item);

        Task Update(Guid id, T item);

        void Delete(Guid id);

    }
}
