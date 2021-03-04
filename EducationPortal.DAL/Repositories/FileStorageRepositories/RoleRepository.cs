using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository(IEducationPortalContext context) : base(context)
        {
        }
    }
}
