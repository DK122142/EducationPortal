using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.FS
{
    public class EducationPortalContext : FSContext
    {
        public FSSet<Video> Videos { get; set; }

        public FSSet<Article> Articles { get; set; }

        public FSSet<Book> Books { get; set; }

        public FSSet<Course> Courses { get; set; }

        public FSSet<Skill> Skills { get; set; }

        public FSSet<Profile> Profiles { get; set; }

        public FSSet<Role> Roles { get; set; }

        public EducationPortalContext(IFileStorageSetInitializer initializer = null) : base(initializer)
        {
            
        }
    }
}
