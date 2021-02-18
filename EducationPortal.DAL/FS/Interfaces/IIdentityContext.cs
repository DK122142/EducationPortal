using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;

namespace EducationPortal.DAL.FS.Interfaces
{
    public interface IIdentityContext : IContext
    {
        FSSet<Account> Accounts { get; set; }
    }
}
