using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class CourseService : Service<Course, CourseDto>, ICourseService
    {
        public CourseService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public OperationDetails AddMaterialToCourse(string courseId, string materialId)
        {
            throw new System.NotImplementedException();
        }

        public OperationDetails RemoveMaterialFromCourse(string courseId, string materialId)
        {
            throw new System.NotImplementedException();
        }

        public OperationDetails AddSkillToCourse(string courseId, string skillId)
        {
            throw new System.NotImplementedException();
        }

        public OperationDetails RemoveSkillFromCourse(string courseId, string skillId)
        {
            throw new System.NotImplementedException();
        }
    }
}
