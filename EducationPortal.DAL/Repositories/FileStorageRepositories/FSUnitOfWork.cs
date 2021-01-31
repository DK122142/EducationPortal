using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class FSUnitOfWork : IUnitOfWork
    {
        private EducationPortalContext context;

        private CourseRepository courseRepository;
        private ArticleRepository articleRepository;
        private VideoRepository videoRepository;
        private BookRepository bookRepository;

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
                    this.videoRepository = new VideoRepository(this.context);
                }

                return this.videoRepository;
            }
        }

        public IRepository<Article> Articles { 
            get
            {
                if (this.articleRepository == null)
                {
                    this.articleRepository = new ArticleRepository(this.context);
                }

                return this.articleRepository;
            }
        }

        public IRepository<Book> Books { 
            get
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new BookRepository(this.context);
                }

                return this.bookRepository;
            } }

        public IRepository<Course> Courses
        {
            get
            {
                if (this.courseRepository == null)
                {
                    this.courseRepository = new CourseRepository(this.context);
                }

                return this.courseRepository;
            }
        }
    }
}
