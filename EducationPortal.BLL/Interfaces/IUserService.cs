using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface IUserService : IService<ProfileDto>
    {
        Task<OperationDetails> JoinToCourse(string userId, string courseId);

        Task<OperationDetails> CompleteCourse(string userId, string courseId);

        Task<OperationDetails<IEnumerable<string>>> CompletedCourses(string userId);
        
        Task<OperationDetails<IEnumerable<string>>> JoinedCourses(string userId);

        Task<OperationDetails<IEnumerable<string>>> CreatedCourses(string userId);

        Task<OperationDetails<IEnumerable<ProfileSkillDto>>> SkillsLevel(string userId);

        Task<OperationDetails<IEnumerable<string>>> PassedMaterials(string userId);





    }
}
