using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Storage
{
    public interface IStorageController
    {
        IStorage Storage { get; }

        IStorageController CreateTable<T>();

        IStorageController DeleteTable<T>();
        
        Task InsertInto<T>(IEnumerable<T> values);

        Task InsertInto<T>(T value);

        void Delete<T>(IEnumerable<T> values);

        void Delete<T>(T value);

        Task Update<T>(Guid id, T value);
    }
}
