using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class ProfileRepository : GenericRepository<Profile>
    {
        public ProfileRepository(IEducationPortalContext context) : base(context)
        {
        }
    }
}
