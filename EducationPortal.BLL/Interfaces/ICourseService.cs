using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.Interfaces
{
    public interface ICourseService : IService<CourseDto>
    {
        public Task<int> CreateCourse(CourseDto course);

        Task<Course> GetByName(string courseName);

        public OperationDetails AddMaterialToCourse(string courseId, string materialId);

        public OperationDetails RemoveMaterialFromCourse(string courseId, string materialId);

        public OperationDetails AddSkillToCourse(string courseId, string skillId);

        public OperationDetails RemoveSkillFromCourse(string courseId, string skillId);
    }
}
