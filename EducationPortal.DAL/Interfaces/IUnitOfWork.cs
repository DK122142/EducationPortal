using EducationPortal.DAL.Entities;

namespace EducationPortal.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Video> Videos { get; }

        IRepository<Article> Articles { get; }

        IRepository<Book> Books { get; }

        IRepository<Course> Courses { get; }

        IRepository<Skill> Skills { get; }

        IRepository<Profile> Profiles { get; }

        IRepository<Role> Roles { get; }
    }
}
