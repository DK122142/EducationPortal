using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class SkillRepository : GenericRepository<Skill>
    {
        public SkillRepository(IEducationPortalContext context) : base(context)
        {
        }
    }
}
