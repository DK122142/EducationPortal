using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;

namespace EducationPortal.DAL.FileStorage.Core.Infrastructure.Interfaces
{
    public interface IDatabase
    {
        IEnumerable<T> GetAll<T>() where T : Entity;

        T Get<T>(Guid id) where T : Entity;

        IEnumerable<T> Find<T>(Func<T, Boolean> predicate) where T : Entity;

        Task CreateAsync<T>(T item) where T : Entity;

        Task UpdateAsync<T>(T item) where T : Entity;

        void Delete<T>(Guid id) where T : Entity;

        bool Any<T>(Func<T, Boolean> predicate) where T : Entity;
    }
}
