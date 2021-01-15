using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Storage
{
    public interface IStorageController
    {
        Storage Storage { get; }

        IStorageController CreateTable<T>();

        IStorageController DeleteTable<T>();
        
        Task InsertInto<T>(IEnumerable<T> values);

        Task InsertInto<T>(T value);

        Task Update<T>(Guid id, T value);
    }
}
