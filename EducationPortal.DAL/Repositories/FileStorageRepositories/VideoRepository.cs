using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class VideoRepository : GenericRepository<Video>
    {
        public VideoRepository(IEducationPortalContext context) : base(context)
        {
        }
    }
}
