using EducationPortal.DAL.FileStorage.Core.Infrastructure.Interfaces;

namespace EducationPortal.DAL.DbContexts.FileStorage.Interfaces
{
    public interface IContext
    {
        IDatabase Db { get; set; }
    }
}
