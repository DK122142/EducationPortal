using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class FSUnitOfWork : IUnitOfWork
    {
        private readonly EducationPortalContext context;
        
        private GenericRepository<Course> courseRepository;
        private GenericRepository<Article> articleRepository;
        private GenericRepository<Video> videoRepository;
        private GenericRepository<Book> bookRepository;
        private GenericRepository<Profile> profileRepository;
        private GenericRepository<Skill> skillRepository;
        private GenericRepository<Role> roleRepository;

        public FSUnitOfWork()
        {
            this.context = new EducationPortalContext();
        }

        public IRepository<Video> Videos
        {
            get
            {
                if (this.videoRepository == null)
                {
                    this.videoRepository = new GenericRepository<Video>(this.context);
                }

                return this.videoRepository;
            }
        }

        public IRepository<Article> Articles { 
            get
            {
                if (this.articleRepository == null)
                {
                    this.articleRepository = new GenericRepository<Article>(this.context);
                }

                return this.articleRepository;
            }
        }

        public IRepository<Book> Books { 
            get
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Book>(this.context);
                }

                return this.bookRepository;
            } }

        public IRepository<Course> Courses
        {
            get
            {
                if (this.courseRepository == null)
                {
                    this.courseRepository = new GenericRepository<Course>(this.context);
                }

                return this.courseRepository;
            }
        }

        public IRepository<Skill> Skills
        {
            get
            {
                if (this.skillRepository == null)
                {
                    this.skillRepository = new GenericRepository<Skill>(this.context);
                }

                return this.skillRepository;
            }
        }

        public IRepository<Profile> Profiles { 
            get
            {
                if (this.profileRepository == null)
                {
                    this.profileRepository = new GenericRepository<Profile>(this.context);
                }

                return this.profileRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(this.context);
                }

                return this.roleRepository;
            }
        }
    }
}
