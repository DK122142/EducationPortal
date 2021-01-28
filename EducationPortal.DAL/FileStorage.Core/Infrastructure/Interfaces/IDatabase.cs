using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.DAL.FileStorage.Core.Infrastructure.Interfaces
{
    public interface IDatabase
    {
        IEnumerable<T> GetAll<T>();

        T Get<T>(Guid id);

        IEnumerable<T> Find<T>(Func<T, Boolean> predicate);

        Task CreateAsync<T>(T item);

        Task UpdateAsync<T>(Guid id, T item);

        void Delete<T>(Guid id);
        
    }
}
