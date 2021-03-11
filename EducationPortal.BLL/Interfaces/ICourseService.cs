using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface ICourseService : IService<CourseDto>
    {
        public OperationDetails AddMaterialToCourse(string courseId, string materialId);

        public OperationDetails RemoveMaterialFromCourse(string courseId, string materialId);

        public OperationDetails AddSkillToCourse(string courseId, string skillId);

        public OperationDetails RemoveSkillFromCourse(string courseId, string skillId);
    }
}
