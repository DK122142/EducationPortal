using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class CourseRepository : GenericRepository<Course>
    {
        public CourseRepository(IEducationPortalContext context) : base(context)
        {
        }
    }
}
