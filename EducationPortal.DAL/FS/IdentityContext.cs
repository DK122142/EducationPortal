using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FileStorage.Core.Infrastructure.Interfaces;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;
using EducationPortal.DAL.FS.Interfaces;

namespace EducationPortal.DAL.FS
{
    public class IdentityContext : FSContext, IIdentityContext
    {
        public IDatabase Db { get; set; }
        public FSSet<Account> Accounts { get; set; }

        public IdentityContext(IFileStorageSetInitializer initializer, string storageName = null) : base(initializer, storageName)
        {
            this.Db = Storage;
        }
    }
}
