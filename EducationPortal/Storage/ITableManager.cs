using System;
using System.Threading.Tasks;

namespace EducationPortal.Storage
{
    public interface ITableManager
    {
        IStorageController StorageController { get; set; }

        Guid Where<T>(string attribute, string value);

        bool AnyEqual<T>(string attribute, string value);

        Task<T> WhereId<T>(Guid id);
    }
}
