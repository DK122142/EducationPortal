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
        
        public UserService(IRepository<Profile> repository, IRepository<Course> courseRepository, IMapper mapper) : base(repository, mapper)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<ResultDetails<Guid>> JoinToCourse(Guid profileId, Guid courseId)
        {
            try
            {
                var profile = await this.repository.FindAsync(profileId);

                var course = await this.courseRepository.FindAsync(courseId);

                profile.JoinedCourses.Add(course);

                await this.repository.SaveChangesAsync();

                return new ResultDetails<Guid>(true, value: course.Id);
            }
            catch
            {
                return new ResultDetails<Guid>(false);
            }
        }

        public async Task<ResultDetails<Guid>> LeaveCourse(Guid profileId, Guid courseId)
        {
            try
            {
                var profile = await this.repository.FindAsync(profileId);

                var course = await this.courseRepository.FindAsync(courseId);

                profile.JoinedCourses.Remove(course);

                await this.repository.SaveChangesAsync();

                return new ResultDetails<Guid>(true, value: course.Id);
            }
            catch
            {
                return new ResultDetails<Guid>(false);
            }
        }

        public async Task<ResultDetails<Guid>> CompleteCourse(Guid profileId, Guid courseId)
        {
            
            try
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

                return new ResultDetails<Guid>(true, value: course.Id);
            }
            catch
            {
                return new ResultDetails<Guid>(false);
            }
        }

        public async Task<ResultDetails<List<CourseDto>>> JoinedCourses(Guid profileId)
        {
            try
            {
                var profile = await this.repository.FindAsync(profileId);

                var joinedCourses = profile.JoinedCourses;

                var joinedCoursesDto = this.mapper.Map<ICollection<CourseDto>>(joinedCourses);

                return new ResultDetails<List<CourseDto>>(true, value: joinedCoursesDto.ToList());
            }
            catch
            {
                return new ResultDetails<List<CourseDto>>(false);
            }
        }

        public async Task<ResultDetails<List<CourseDto>>> CompletedCourses(Guid profileId)
        {
            try
            {
                var profile = await this.repository.FindAsync(profileId);

                var completedCourses = profile.CompletedCourses;

                var completedCoursesDto = this.mapper.Map<ICollection<CourseDto>>(completedCourses);
                
                return new ResultDetails<List<CourseDto>>(true, value: completedCoursesDto.ToList());
            }
            catch
            {
                return new ResultDetails<List<CourseDto>>(false);
            }
        }

        public async Task<ResultDetails<List<MaterialDto>>> LearnedMaterials(Guid profileId)
        {
            try
            {
                var profile = await this.repository.FindAsync(profileId);

                var materials = profile.PassedMaterials;

                var materialsDto = this.mapper.Map<ICollection<MaterialDto>>(materials);
                
                return new ResultDetails<List<MaterialDto>>(true, value: materialsDto.ToList());
            }
            catch
            {
                return new ResultDetails<List<MaterialDto>>(false);
            }
        }

        public async Task<ResultDetails<List<ProfileSkillDto>>> ProfileSkills(Guid profileId)
        {
            try
            {
                var profile = await this.repository.FindAsync(profileId);

                var profileSkills = profile.ProfileSkills;

                var psDto = this.mapper.Map<IList<ProfileSkillDto>>(profileSkills);

                return new ResultDetails<List<ProfileSkillDto>>(true, value: psDto.ToList());
            }
            catch
            {
                return new ResultDetails<List<ProfileSkillDto>>(false);
            }
        }
    }
}
