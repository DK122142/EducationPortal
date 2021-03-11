using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;

namespace EducationPortal.DAL.DbContexts.FileStorage.Interfaces
{
    public interface IEducationPortalContext : IContext
    {
        public FSSet<Video> Videos { get; set; }

        public FSSet<Article> Articles { get; set; }

        public FSSet<Book> Books { get; set; }

        public FSSet<Course> Courses { get; set; }

        public FSSet<Skill> Skills { get; set; }

        public FSSet<Profile> Profiles { get; set; }

        public FSSet<Role> Roles { get; set; }
    }
}
