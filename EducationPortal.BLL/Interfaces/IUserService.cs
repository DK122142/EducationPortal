using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface IUserService : IService<ProfileDto>
    {
        Task<OperationDetails> JoinToCourse(Guid userId, CourseDto courseToJoin);

        Task<OperationDetails> CompleteCourse(Guid userId, CourseDto courseToComplete);

        Task<OperationDetails<IEnumerable<Guid>>> CompletedCourses(Guid userId);
        
        Task<OperationDetails<IEnumerable<Guid>>> JoinedCourses(Guid userId);

        Task<OperationDetails<IEnumerable<Guid>>> CreatedCourses(Guid userId);

        Task<OperationDetails<IEnumerable<ProfileSkillDto>>> SkillsLevel(Guid userId);

        Task<OperationDetails<IEnumerable<Guid>>> PassedMaterials(Guid userId);





    }
}
