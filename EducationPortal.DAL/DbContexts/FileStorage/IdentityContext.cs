using EducationPortal.DAL.DbContexts.FileStorage.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FileStorage.Core.Infrastructure.Interfaces;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.DbContexts.FileStorage
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
