using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Storage
{
    public interface ITableManager
    {
        IStorageController StorageController { get; set; }

        List<Guid> Where<T>(string attribute, string value);

        bool AnyEqual<T>(string attribute, string value);

        Task<T> WhereId<T>(Guid id);
    }
}
