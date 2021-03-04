using EducationPortal.DAL.FileStorage.Core.Infrastructure.Interfaces;

namespace EducationPortal.DAL.FS.Interfaces
{
    public interface IContext
    {
        IDatabase Db { get; set; }
    }
}
