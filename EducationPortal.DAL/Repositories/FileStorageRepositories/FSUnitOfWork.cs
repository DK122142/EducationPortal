using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class FSUnitOfWork : IUnitOfWork
    {
        private readonly IEducationPortalContext context;
        
        private IRepository<Course> courseRepository;
        private IRepository<Article> articleRepository;
        private IRepository<Video> videoRepository;
        private IRepository<Book> bookRepository;
        private IRepository<Profile> profileRepository;
        private IRepository<Skill> skillRepository;
        private IRepository<Role> roleRepository;

        public FSUnitOfWork(IEducationPortalContext educationPortalContext)
        {
            this.context = educationPortalContext;
        }

        public IRepository<Video> Videos => this.videoRepository ??= new VideoRepository(this.context);

        public IRepository<Article> Articles => this.articleRepository ??= new ArticleRepository(this.context);

        public IRepository<Book> Books => this.bookRepository ??= new BookRepository(this.context);

        public IRepository<Course> Courses => this.courseRepository ??= new CourseRepository(this.context);

        public IRepository<Skill> Skills => this.skillRepository ??= new SkillRepository(this.context);

        public IRepository<Profile> Profiles => this.profileRepository ??= new ProfileRepository(this.context);

        public IRepository<Role> Roles => this.roleRepository ??= new RoleRepository(this.context);
    }
}
