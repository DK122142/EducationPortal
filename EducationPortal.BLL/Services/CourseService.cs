using AutoMapper;
using EducationPortal.BLL.DTO;
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
    }
}
