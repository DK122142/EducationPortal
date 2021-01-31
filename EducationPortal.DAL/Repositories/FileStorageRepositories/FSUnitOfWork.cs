using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class FSUnitOfWork : IUnitOfWork
    {
        private readonly EducationPortalContext _context;

        private CourseRepository _courseRepository;
        private ArticleRepository _articleRepository;
        private VideoRepository _videoRepository;
        private BookRepository _bookRepository;
        private ProfileRepository _profileRepository;
        private SkillRepository _skillRepository;

        public FSUnitOfWork()
        {
            this._context = new EducationPortalContext();
        }

        public IRepository<Video> Videos
        {
            get
            {
                if (this._videoRepository == null)
                {
                    this._videoRepository = new VideoRepository(this._context);
                }

                return this._videoRepository;
            }
        }

        public IRepository<Article> Articles { 
            get
            {
                if (this._articleRepository == null)
                {
                    this._articleRepository = new ArticleRepository(this._context);
                }

                return this._articleRepository;
            }
        }

        public IRepository<Book> Books { 
            get
            {
                if (this._bookRepository == null)
                {
                    this._bookRepository = new BookRepository(this._context);
                }

                return this._bookRepository;
            } }

        public IRepository<Course> Courses
        {
            get
            {
                if (this._courseRepository == null)
                {
                    this._courseRepository = new CourseRepository(this._context);
                }

                return this._courseRepository;
            }
        }

        public IRepository<Skill> Skills
        {
            get
            {
                if (this._skillRepository == null)
                {
                    this._skillRepository = new SkillRepository(this._context);
                }

                return this._skillRepository;
            }
        }

        public IRepository<Profile> Profiles { 
            get
            {
                if (this._profileRepository == null)
                {
                    this._profileRepository = new ProfileRepository(this._context);
                }

                return this._profileRepository;
            }
        }
    }
}
