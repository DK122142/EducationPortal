using System;
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
        private readonly ICourseService courseService;

        public UserService(IUnitOfWork uow, IMapper mapper, ICourseService courseService) : base(uow, mapper)
        {
            this.courseService = courseService;
        }

        public async Task<OperationDetails> JoinToCourse(Guid userId, CourseDto courseToJoin)
        {
            var course = await this.courseService.GetByName(courseToJoin.Name);

            var response = await this.JoinedCourses(userId);
            var joinedCourses = response.Value;

            if (joinedCourses.Contains(course.Id))
            {
                return new OperationDetails(false, $"User {userId} already joined to course {course.Name}",
                    $"{userId};{course.Id};{course.Name}");
            }

            var user = await this.repository.GetById(userId);
            user.JoinedCourses.Add(course);
            course.JoinedProfiles.Add(user);
            
            if (await this.uow.Commit() > 0)
            {
                return new OperationDetails(true);
            }
            else
            {
                return new OperationDetails(false);
            }
        }

        
        //TODO update skill level
        public async Task<OperationDetails> CompleteCourse(Guid userId, CourseDto courseToComplete)
        {
            var course = await this.courseService.GetByName(courseToComplete.Name);

            var response = await this.CompletedCourses(userId);
            var completedCourses = response.Value;

            if (completedCourses.Contains(course.Id))
            {
                return new OperationDetails(false, $"User {userId} already completed course {course.Name}",
                    $"{userId};{course.Id};{course.Name}");
            }
            
            var user = await this.repository.GetById(userId);

            user.JoinedCourses.Remove(course);
            user.CompletedCourses.Add(course);

            course.JoinedProfiles.Remove(user);
            course.CompletedProfiles.Add(user);
            
            if (await this.uow.Commit() > 0)
            {
                return new OperationDetails(true);
            }
            else
            {
                return new OperationDetails(false);
            }
        }

        public async Task<OperationDetails<IEnumerable<Guid>>> CompletedCourses(Guid userId)
        {
            var user = await this.GetById(userId);

            return new OperationDetails<IEnumerable<Guid>>(true, value: user.CompletedCoursesId);
        }

        public async Task<OperationDetails<IEnumerable<Guid>>> JoinedCourses(Guid userId)
        {
            var user = await this.GetById(userId);

            return new OperationDetails<IEnumerable<Guid>>(true, value: user.JoinedCoursesId);
        }

        public Task<OperationDetails<IEnumerable<Guid>>> CreatedCourses(Guid userId)
        {
            throw new NotImplementedException();
            // var user = await this.GetById(userId);
            //
            // return new OperationDetails<IEnumerable<string>>(true, value: user.CreatedCoursesId);
        }

        public async Task<OperationDetails<IEnumerable<ProfileSkillDto>>> SkillsLevel(Guid userId)
        {
            var user = await this.GetById(userId);
            var skills = user.SkillsId;
            var psRepository = this.uow.Repository<ProfileSkill>();

            var skillsLevels = psRepository.Where(ps => skills.Contains(ps.Id)).AsEnumerable();

            return new OperationDetails<IEnumerable<ProfileSkillDto>>(true,
                value: this.mapper.Map<IEnumerable<ProfileSkillDto>>(skillsLevels));
        }

        public async Task<OperationDetails<IEnumerable<Guid>>> PassedMaterials(Guid userId)
        {
            var user = await this.GetById(userId);

            return new OperationDetails<IEnumerable<Guid>>(true, value: user.PassedMaterialsId);
        }
    }
}
