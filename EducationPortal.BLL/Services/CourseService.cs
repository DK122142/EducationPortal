using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class CourseService : Service<Course, CourseDto>, ICourseService
    {
        private IMaterialService materialService;
        private ISkillService skillService;

        public CourseService(IMapper mapper,  IMaterialService materialService, ISkillService skillService) : base(uow, mapper)
        {
            this.materialService = materialService;
            this.skillService = skillService;
        }

        public async Task<int> CreateCourse(CourseDto course)
        {
            var courseEntity = this.mapper.Map<Course>(course);
            
            if (courseEntity.Materials == null)
            {
                courseEntity.Materials = new List<Material>();
            }

            if (courseEntity.Skills == null)
            {
                courseEntity.Skills = new List<Skill>();
            }

            var courseMaterials = courseEntity.Materials;
            var courseSkills = courseEntity.Skills.ToList();
            
            foreach (var name in course.MaterialNames)
            {
                courseMaterials.Add(await this.materialService.GetMaterialByName(name.Trim()));
            }

            foreach (var name in course.SkillNames)
            {
                courseSkills.Add(await this.skillService.GetSkillByName(name.Trim()));
            }

            courseEntity.Materials = courseMaterials;
            courseEntity.Skills = courseSkills;

            foreach (var courseMaterial in courseMaterials)
            {
                var included = courseMaterial.IncludedIn.ToList();

                included.Add(courseEntity);

                courseMaterial.IncludedIn = included;

            }

            this.uow.Repository<Material>().Update(courseMaterials);
            await this.repository.Add(courseEntity);

            var res = await this.uow.Commit();

            return res;
        }

        public async Task<Course> GetByName(string courseName)
        {
            return await this.repository.Single(s => s.Name.Equals(courseName));
        }

        public void JoinToCourse(string userId, CourseDto course)
        {
            throw new System.NotImplementedException();
        }

        public OperationDetails AddMaterialToCourse(string courseId, string materialId)
        {
            throw new System.NotImplementedException();
        }

        public OperationDetails RemoveMaterialFromCourse(string courseId, string materialId)
        {
            throw new System.NotImplementedException();
        }

        public OperationDetails AddSkillToCourse(string courseId, string skillId)
        {
            throw new System.NotImplementedException();
        }

        public OperationDetails RemoveSkillFromCourse(string courseId, string skillId)
        {
            throw new System.NotImplementedException();
        }
    }
}
