using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.WEB.MVC.Models;
using EducationPortal.WEB.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.WEB.MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICourseService courseService;
        private readonly ISkillService skillService;
        private readonly IMaterialService materialService;

        public CourseController(IMapper mapper, ICourseService courseService, ISkillService skillService, IMaterialService materialService)
        {
            this.courseService = courseService;
            this.skillService = skillService;
            this.materialService = materialService;
            this.mapper = mapper;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var skill = await this.courseService.GetByIdAsync(id);

            if (skill == null)
            {
                return BadRequest();
            }

            return new ObjectResult(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CourseCreateViewModel model)
        {
            var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var dto = this.mapper.Map<CourseDto>(model);
        
            await this.courseService.Create(Guid.Parse(creatorId), dto);
            
            return Ok(model);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.courseService.DeleteAsync(id);
            return Ok();
        }
        
        [HttpGet("Details/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var courseDto = await this.courseService.GetByIdAsync(id);
            var skillsDto = new List<SkillDto>();
            var materialsDto = new List<MaterialDto>();
            
            foreach (var skillId in courseDto.SkillsId)
            {
                var skill = await this.skillService.GetByIdAsync(skillId);

                skillsDto.Add(skill);
            }

            foreach (var materialId in courseDto.MaterialsId)
            {
                var material = await materialService.GetByIdAsync(materialId);

                materialsDto.Add(material);
            }

            var course = this.mapper.Map<CourseViewModel>(courseDto);
            var skills = this.mapper.Map<IEnumerable<SkillModel>>(skillsDto);
            var materials = this.mapper.Map<IEnumerable<MaterialModel>>(materialsDto);

            course.Skills = skills;
            course.Materials = materials;

            return new ObjectResult(course);
        }
        
        [Authorize]
        [HttpPost("addskill/{courseId:Guid}/{id:Guid}")]
        public async Task<IActionResult> AddSkill(Guid courseId, Guid id)
        {
            await this.courseService.AddSkillToCourse(id, courseId);

            return Ok();
        }

        [Authorize]
        [HttpPost("addmaterial{courseId:Guid}/{id:Guid}")]
        public async Task<IActionResult> AddMaterial(Guid courseId, Guid id)
        {
            await this.courseService.AddMaterialToCourse(id, courseId);

            return Ok();
        }
    }
}
