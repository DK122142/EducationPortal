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
using Microsoft.Extensions.Logging;

namespace EducationPortal.WEB.MVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICourseService service;
        private readonly ISkillService skillService;
        private readonly IMaterialService materialService;
        private readonly ILogger logger;

        public CourseController(IMapper mapper, ICourseService service, ISkillService skillService, IMaterialService materialService, ILogger<CourseController> logger)
        {
            this.service = service;
            this.skillService = skillService;
            this.materialService = materialService;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;

            var count = await this.service.TotalCountAsync();

            var materials = await this.service.GetPageAsync(page, pageSize);

            var pvm = new PageViewModel(count, page, pageSize);

            var viewModel = new PaginationViewModel<CourseModel>
            {
                PageViewModel = pvm,
                Models = this.mapper.Map<IEnumerable<CourseModel>>(materials)
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create() => View();
        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
                var dto = this.mapper.Map<CourseDto>(model);
        
                await this.service.Create(Guid.Parse(creatorId), dto);

                this.logger.LogInformation($"Course {model.Name} created by {creatorId}");
            
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var courseDto = await this.service.GetByIdAsync(id);
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

            return View(course);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddSkills(Guid courseId, int page = 1)
        {
            int pageSize = 100;
        
            var skillsCount = await this.skillService.TotalCountAsync();
        
            var skills = await this.skillService.GetPageAsync(page, pageSize);
        
            var pvm = new PageViewModel(skillsCount, page, pageSize);
        
            var paginationViewModel = new PaginationViewModel<SkillModel>
            {
                PageViewModel = pvm,
                Models = this.mapper.Map<IEnumerable<SkillModel>>(skills)
            };
            
            // Course model data
            var courseDto = await this.service.GetByIdAsync(courseId);
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
            var skillModels = this.mapper.Map<IEnumerable<SkillModel>>(skillsDto);
            var materials = this.mapper.Map<IEnumerable<MaterialModel>>(materialsDto);

            course.Skills = skillModels;
            course.Materials = materials;

            var viewModel = new CourseContinueCreateViewModel
            {
                CourseModel = course,
                Skills = paginationViewModel
            };
        
            return View(viewModel);
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddMaterials(Guid courseId, int page = 1)
        {
            int pageSize = 100;
        
            var count = await this.materialService.TotalCountAsync();
        
            var skills = await this.materialService.GetPageAsync(page, pageSize);
        
            var pvm = new PageViewModel(count, page, pageSize);
        
            var paginationViewModel = new PaginationViewModel<MaterialModel>
            {
                PageViewModel = pvm,
                Models = this.mapper.Map<IEnumerable<MaterialModel>>(skills)
            };
            
            // Course model data
            var courseDto = await this.service.GetByIdAsync(courseId);
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
            var skillModels = this.mapper.Map<IEnumerable<SkillModel>>(skillsDto);
            var materials = this.mapper.Map<IEnumerable<MaterialModel>>(materialsDto);

            course.Skills = skillModels;
            course.Materials = materials;

            var viewModel = new CourseContinueCreateViewModel
            {
                CourseModel = course,
                Materials = paginationViewModel
            };
        
            return View(viewModel);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddSkill(Guid courseId, Guid id)
        {
            await this.service.AddSkillToCourse(id, courseId);
            
            this.logger.LogInformation($"Added skill {id} to course {courseId}");

            return RedirectToAction("AddSkills", new {courseId = courseId});
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddMaterial(Guid courseId, Guid id)
        {
            await this.service.AddMaterialToCourse(id, courseId);

            this.logger.LogInformation($"Added material {id} to course {courseId}");

            return RedirectToAction("AddMaterials", new {courseId = courseId});
        }
        
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                await this.service.DeleteAsync(id);
                
                this.logger.LogInformation($"Deleted course {id}");
            }

            return RedirectToAction("Index");
        }
    }
}
