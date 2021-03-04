using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class ArticleRepository : GenericRepository<Article>
    {
        public ArticleRepository(IEducationPortalContext context) : base(context)
        {
        }
    }
}
