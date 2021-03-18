﻿using System;
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

        public IQueryable<SkillDto> SearchSkill(string searchString)
        {
            var skills = this.skillRepository.FindBy(s => s.Name.Contains(searchString));

            var dto = this.mapper.Map<IQueryable<SkillDto>>(skills);

            return dto;
        }

        public void SearchMaterial(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
