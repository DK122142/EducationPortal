using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using Profile = EducationPortal.DAL.Entities.Profile;

namespace EducationPortal.BLL.Services
{
    public class UserService : Service<Profile, ProfileDto>, IUserService
    {
        public UserService(IUnitOfWork uow, IMapper mapper, IUserService userService) : base(uow, mapper)
        {
        }

        public async Task<OperationDetails> JoinToCourse(string userId, string courseId)
        {
            var courseRepository = this.uow.Repository<Course>();

            var course = await courseRepository.GetById(courseId);

            var joinedCourses = await this.JoinedCourses(userId);

            if (joinedCourses.Value.Contains(course.Id))
            {
                return new OperationDetails(false, $"User {userId} already joined to course {course.Name}",
                    $"{userId};{course.Id};{course.Name}");
            }

            var user = await this.GetById(userId);
            user.JoinedCoursesId.ToList().Add(course.Id);

            this.repository.Update(this.mapper.Map<Profile>(user));

            if (await this.uow.Commit() > 0)
            {
                return new OperationDetails(true);
            }
            else
            {
                return new OperationDetails(false);
            }
        }

        public async Task<OperationDetails> CompleteCourse(string userId, string courseId)
        {
            var courseRepository = this.uow.Repository<Course>();

            var course = await courseRepository.GetById(courseId);

            var completedCourses = await this.CompletedCourses(userId);

            if (completedCourses.Value.Contains(course.Id))
            {
                return new OperationDetails(false, $"User {userId} already completed course {course.Name}",
                    $"{userId};{course.Id};{course.Name}");
            }

            var user = await this.GetById(userId);
            user.JoinedCoursesId.ToList().Remove(course.Id);
            user.CompletedCoursesId.ToList().Add(course.Id);

            this.repository.Update(this.mapper.Map<Profile>(user));

            await this.uow.Commit();
            
            if (await this.uow.Commit() > 0)
            {
                return new OperationDetails(true);
            }
            else
            {
                return new OperationDetails(false);
            }
        }

        public async Task<OperationDetails<IEnumerable<string>>> CompletedCourses(string userId)
        {
            var user = await this.GetById(userId);

            return new OperationDetails<IEnumerable<string>>(true, value: user.CompletedCoursesId);
        }

        public async Task<OperationDetails<IEnumerable<string>>> JoinedCourses(string userId)
        {
            var user = await this.GetById(userId);

            return new OperationDetails<IEnumerable<string>>(true, value: user.JoinedCoursesId);
        }

        public async Task<OperationDetails<IEnumerable<string>>> CreatedCourses(string userId)
        {
            var user = await this.GetById(userId);

            return new OperationDetails<IEnumerable<string>>(true, value: user.CreatedCoursesId);
        }

        public async Task<OperationDetails<IEnumerable<ProfileSkillDto>>> SkillsLevel(string userId)
        {
            var user = await this.GetById(userId);
            var skills = user.SkillsId;
            var psRepository = this.uow.Repository<ProfileSkill>();

            var skillsLevels = psRepository.Where(ps => skills.Contains(ps.Id)).AsEnumerable();

            return new OperationDetails<IEnumerable<ProfileSkillDto>>(true,
                value: this.mapper.Map<IEnumerable<ProfileSkillDto>>(skillsLevels));
        }

        public async Task<OperationDetails<IEnumerable<string>>> PassedMaterials(string userId)
        {
            var user = await this.GetById(userId);

            return new OperationDetails<IEnumerable<string>>(true, value: user.PassedMaterialsId);
        }
    }
}
