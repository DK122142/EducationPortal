using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationPortal.DAL.FileStorage.Core.Infrastructure.Interfaces
{
    public interface IDatabase
    {
        IEnumerable<T> GetAll<T>();
        // where T : Entity;

        T Get<T>(string id);
        // where T : Entity;

        IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate);
            // where T : Entity;

        Task CreateAsync<T>(T item);
            // where T : Entity;

        Task UpdateAsync<T>(T item);
        // where T : Entity;

        void Delete<T>(string id);
            // where T : Entity;

        bool Any<T>(Expression<Func<T, bool>> predicate);
            // where T : Entity;
    }
}
