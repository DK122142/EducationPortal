using EducationPortal.DAL.DbContexts.FileStorage.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FileStorage.Core.Infrastructure.Interfaces;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.DbContexts.FileStorage
{
    public class EducationPortalContext : FSContext, IEducationPortalContext
    {
        public IDatabase Db { get; set; }
        public FSSet<Video> Videos { get; set; }
        public FSSet<Article> Articles { get; set; }
        public FSSet<Book> Books { get; set; }
        public FSSet<Course> Courses { get; set; }
        public FSSet<Skill> Skills { get; set; }
        public FSSet<Profile> Profiles { get; set; }
        // public FSSet<Role> Roles { get; set; }

        public EducationPortalContext(IFileStorageSetInitializer initializer, string storageName = null) : base(initializer, storageName)
        {
            this.Db = Storage;
        }
    }
}
