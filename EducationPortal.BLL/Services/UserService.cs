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
        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<Skill> skillRepository;
        
        public UserService(IRepository<Profile> repository, IRepository<Course> courseRepository, IMapper mapper, IRepository<Skill> skillRepository) : base(repository, mapper)
        {
            this.courseRepository = courseRepository;
            this.skillRepository = skillRepository;
        }

        // public async Task<OperationDetails> JoinToCourse(Guid userId, CourseDto courseToJoin)
        // {
        //     
        //     throw new NotImplementedException();
        //     // var course = await this.courseRepository.GetByName(courseToJoin.Name);
        //
        //     // var response = await this.JoinedCourses(userId);
        //     // var joinedCourses = response.Value;
        //     //
        //     // if (joinedCourses.Contains(course.Id))
        //     // {
        //     //     return new OperationDetails(false, $"User {userId} already joined to course {course.Name}",
        //     //         $"{userId};{course.Id};{course.Name}");
        //     // }
        //
        //     // var user = await this.GetByIdAsync(userId);
        //     // user.JoinedCourses.Add(course);
        //     // course.JoinedProfiles.Add(user);
        //
        //     // await this.repository.SaveChangesAsync();
        //     //
        //     // return new OperationDetails(true);
        //     
        // }
        //
        //
        // //TODO update skill level
        // public async Task<OperationDetails> CompleteCourse(Guid userId, CourseDto courseToComplete)
        // {
        //     // var course = await this.courseRepository.GetByName(courseToComplete.Name);
        //     //
        //     // var response = await this.CompletedCourses(userId);
        //     // var completedCourses = response.Value;
        //     //
        //     // if (completedCourses.Contains(course.Id))
        //     // {
        //     //     return new OperationDetails(false, $"User {userId} already completed course {course.Name}",
        //     //         $"{userId};{course.Id};{course.Name}");
        //     // }
        //     //
        //     // var user = await this.GetByIdAsync(userId);
        //
        //     // user.JoinedCourses.Remove(course);
        //     // user.CompletedCourses.Add(course);
        //
        //     // course.JoinedProfiles.Remove(user);
        //     // course.CompletedProfiles.Add(user);
        //     
        //     // await this.repository.SaveChangesAsync();
        //     //
        //     // return new OperationDetails(true);
        //     
        //     throw new NotImplementedException();
        // }
        //
        // public async Task<OperationDetails<IEnumerable<Guid>>> CompletedCourses(Guid userId)
        // {
        //     var user = await this.GetByIdAsync(userId);
        //
        //     return new OperationDetails<IEnumerable<Guid>>(true, value: user.CompletedCoursesId);
        // }
        //
        // public async Task<OperationDetails<IEnumerable<Guid>>> JoinedCourses(Guid userId)
        // {
        //     var user = await this.GetByIdAsync(userId);
        //
        //     return new OperationDetails<IEnumerable<Guid>>(true, value: user.JoinedCoursesId);
        // }
        //
        // public Task<OperationDetails<IEnumerable<Guid>>> CreatedCourses(Guid userId)
        // {
        //     throw new NotImplementedException();
        //     // var user = await this.GetByIdAsync(userId);
        //     //
        //     // return new OperationDetails<IEnumerable<string>>(true, value: user.CreatedCoursesId);
        // }
        //
        // public async Task<OperationDetails<IEnumerable<ProfileSkillDto>>> SkillsLevel(Guid userId)
        // {
        //     // var user = await this.GetByIdAsync(userId);
        //     // var skills = user.SkillsId;
        //     // var psRepository = this.uow.Repository<ProfileSkill>();
        //     //
        //     // var skillsLevels = psRepository.Where(ps => skills.Contains(ps.Id)).AsEnumerable();
        //     //
        //     // return new OperationDetails<IEnumerable<ProfileSkillDto>>(true,
        //     //     value: this.mapper.Map<IEnumerable<ProfileSkillDto>>(skillsLevels));
        //
        //     return new(false);
        // }
        //
        // public async Task<OperationDetails<IEnumerable<Guid>>> PassedMaterials(Guid userId)
        // {
        //     var user = await this.GetByIdAsync(userId);
        //
        //     return new OperationDetails<IEnumerable<Guid>>(true, value: user.PassedMaterialsId);
        // }

        public async Task JoinToCourse(Guid profileId, Guid courseId)
        {
            var profile = await this.repository.FindAsync(profileId);

            var course = await this.courseRepository.FindAsync(courseId);

            profile.JoinedCourses.Add(course);

            await this.repository.SaveChangesAsync();
        }

        public async Task LeaveCourse(Guid profileId, Guid courseId)
        {
            var profile = await this.repository.FindAsync(profileId);

            var course = await this.courseRepository.FindAsync(courseId);

            profile.JoinedCourses.Remove(course);

            await this.repository.SaveChangesAsync();
        }

        public async Task CompleteCourse(Guid profileId, Guid courseId)
        {
            var profile = await this.repository.FindAsync(profileId);

            var course = await this.courseRepository.FindAsync(courseId);

            profile.JoinedCourses.Remove(course);
            profile.CompletedCourses.Add(course);

            // Adding materials
            foreach (var courseMaterial in course.Materials)
            {
                if (!profile.PassedMaterials.Contains(courseMaterial))
                {
                    profile.PassedMaterials.Add(courseMaterial);
                }
            }
            
            // Adding skills
            foreach (var courseSkill in course.Skills)
            {
                if (profile.ProfileSkills.Select(ps=>ps.SkillId).Contains(courseSkill.Id))
                {
                    profile.ProfileSkills.FirstOrDefault(ps =>
                        ps.SkillId.Equals(courseSkill.Id) && ps.ProfileId.Equals(profile.Id)).Level += 1;
                }
                else
                {
                    profile.ProfileSkills.Add(new ProfileSkill
                    {
                        Level = 1,
                        Profile = profile,
                        ProfileId = profile.Id,
                        Skill = courseSkill,
                        SkillId = courseSkill.Id
                    });
                }
            }

            await this.repository.SaveChangesAsync();
        }
    }
}
