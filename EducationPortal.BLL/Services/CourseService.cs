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
    public class CourseService : Service<Course, CourseDto>, ICourseService
    {
        private readonly IRepository<Material> materialRepository;
        private readonly IRepository<Skill> skillRepository;
        private readonly IRepository<Profile> profileRepository;
        
        public CourseService(IRepository<Course> repository, IRepository<Material> materialRepository, IRepository<Skill> skillRepository, IMapper mapper, IRepository<Profile> profileRepository) : base(repository, mapper)
        {
            this.materialRepository = materialRepository;
            this.skillRepository = skillRepository;
            this.profileRepository = profileRepository;
        }

        public async Task<ResultDetails> Create(Guid creatorId, CourseDto course)
        {
            try
            {
                var creator = await this.profileRepository.GetByIdAsync(creatorId);
            
                var newCourse = this.mapper.Map<Course>(course);

                newCourse.Creator = creator;

                await this.repository.AddAsync(newCourse);

                await this.repository.SaveChangesAsync();

                return new ResultDetails(true);
            }
            catch
            {
                return new ResultDetails(false);
            }
        }

        public async Task<ResultDetails> Edit(CourseDto course)
        {
            try
            {
                var skills = await this.skillRepository.FindBy(s => course.SkillsId.Contains(s.Id));

                var materials = await this.materialRepository.FindBy(m => course.MaterialsId.Contains(m.Id));

                var updatedCourse = this.mapper.Map<Course>(course);
            
                updatedCourse.Skills = skills as ICollection<Skill>;
                updatedCourse.Materials = materials.ToList();

                this.repository.Update(updatedCourse);

                await this.repository.SaveChangesAsync();

                return new ResultDetails(true);
            }
            catch
            {
                return new ResultDetails(false);
            }
        }

        public async Task<ResultDetails> AddSkillToCourse(Guid skillId, Guid courseId)
        {
            try
            {
                var skill = await this.skillRepository.GetByIdAsync(skillId);

                var course = await this.repository.GetByIdAsync(courseId);

                course.Skills.Add(skill);

                await this.repository.SaveChangesAsync();

                return new ResultDetails(true);
            }
            catch
            {
                return new ResultDetails(false);
            }

        }

        public async Task<ResultDetails> AddMaterialToCourse(Guid materialId, Guid courseId)
        {
            try
            {
                var material = await this.materialRepository.GetByIdAsync(materialId);

                var course = await this.repository.GetByIdAsync(courseId);

                course.Materials.Add(material);

                await this.repository.SaveChangesAsync();

                return new ResultDetails(true);
            }
            catch
            {
                return new ResultDetails(false);
            }

        }

        public async Task<ResultDetails> RemoveSkillFromCourse(Guid skillId, Guid courseId)
        {
            try
            {
                var skill = await this.skillRepository.GetByIdAsync(skillId);

                var course = await this.repository.GetByIdAsync(courseId);

                course.Skills.Remove(skill);

                await this.repository.SaveChangesAsync();

                return new ResultDetails(true);
            }
            catch
            {
                return new ResultDetails(false);
            }

        }

        public async Task<ResultDetails> RemoveMaterialFromCourse(Guid materialId, Guid courseId)
        {
            try
            {
                var material = await this.materialRepository.GetByIdAsync(materialId);

                var course = await this.repository.GetByIdAsync(courseId);

                course.Materials.Remove(material);

                await this.repository.SaveChangesAsync();

                return new ResultDetails(true);
            }
            catch
            {
                return new ResultDetails(false);
            }
        }
    }
}
