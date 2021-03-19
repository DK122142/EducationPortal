using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Profile = EducationPortal.DAL.Entities.Profile;

namespace EducationPortal.BLL.Services
{
    public class CourseService : Service<Course, CourseDto>, ICourseService
    {
        private IRepository<Material> materialRepository;
        private IRepository<Skill> skillRepository;
        private IRepository<Profile> profileRepository;
        
        public CourseService(IRepository<Course> repository, IRepository<Material> materialRepository, IRepository<Skill> skillRepository, IMapper mapper, IRepository<Profile> profileRepository) : base(repository, mapper)
        {
            this.materialRepository = materialRepository;
            this.skillRepository = skillRepository;
            this.profileRepository = profileRepository;
        }

        public async Task<Guid> Create(Guid creatorId, CourseDto course)
        {
            var creator = await this.profileRepository.FindAsync(creatorId);
            
            var newCourse = this.mapper.Map<Course>(course);

            newCourse.Id = Guid.NewGuid();
            newCourse.Creator = creator;

            await this.repository.AddAsync(newCourse);

            await this.repository.SaveChangesAsync();

            return newCourse.Id;
        }

        public async Task Edit(CourseDto course)
        {
            var skills = this.skillRepository.FindBy(s => course.SkillsId.Contains(s.Id));

            var materials = this.materialRepository.FindBy(m => course.MaterialsId.Contains(m.Id));

            var updatedCourse = this.mapper.Map<Course>(course);
            
            updatedCourse.Skills = await skills.ToListAsync();
            updatedCourse.Materials = await materials.ToListAsync();

            this.repository.Update(updatedCourse);

            await this.repository.SaveChangesAsync();
        }

        public async Task AddSkillToCourse(Guid skillId, Guid courseId)
        {
            var skill = await this.skillRepository.FindAsync(skillId);

            var course = await this.repository.FindAsync(courseId);

            course.Skills.Add(skill);

            await this.repository.SaveChangesAsync();
        }

        public async Task AddMaterialToCourse(Guid materialId, Guid courseId)
        {
            var material = await this.materialRepository.FindAsync(materialId);

            var course = await this.repository.FindAsync(courseId);

            course.Materials.Add(material);

            await this.repository.SaveChangesAsync();
        }
    }
}
