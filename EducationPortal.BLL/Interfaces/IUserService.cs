using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.DAL.Entities;
using Microsoft.AspNetCore.Identity;

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
