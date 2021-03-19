using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using Profile = EducationPortal.DAL.Entities.Profile;

namespace EducationPortal.BLL.Services
{
    public class UserService : Service<Profile, ProfileDto>, IUserService
    {
        private readonly IRepository<Course> courseRepository;
        
        public UserService(IRepository<Profile> repository, IRepository<Course> courseRepository, IMapper mapper) : base(repository, mapper)
        {
            this.courseRepository = courseRepository;
        }

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

        public async Task<List<CourseDto>> JoinedCourses(Guid profileId)
        {
            var profile = await this.repository.FindAsync(profileId);

            var joinedCourses = profile.JoinedCourses;

            var joinedCoursesDto = this.mapper.Map<ICollection<CourseDto>>(joinedCourses);

            return joinedCoursesDto.ToList();
        }

        public async Task<List<CourseDto>> CompletedCourses(Guid profileId)
        {
            var profile = await this.repository.FindAsync(profileId);

            var completedCourses = profile.CompletedCourses;

            var completedCoursesDto = this.mapper.Map<ICollection<CourseDto>>(completedCourses);

            return completedCoursesDto.ToList();
        }

        public async Task<List<MaterialDto>> LearnedMaterials(Guid profileId)
        {
            var profile = await this.repository.FindAsync(profileId);

            var materials = profile.PassedMaterials;

            var materialsDto = this.mapper.Map<ICollection<MaterialDto>>(materials);

            return materialsDto.ToList();
        }

        public async Task<List<ProfileSkillDto>> ProfileSkills(Guid profileId)
        {
            var profile = await this.repository.FindAsync(profileId);

            var profileSkills = profile.ProfileSkills;

            var psDto = this.mapper.Map<IList<ProfileSkillDto>>(profileSkills);

            return psDto.ToList();
        }
    }
}
