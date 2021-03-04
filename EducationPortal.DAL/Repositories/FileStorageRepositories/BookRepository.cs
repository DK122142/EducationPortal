using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(IEducationPortalContext context) : base(context)
        {
        }
    }
}
