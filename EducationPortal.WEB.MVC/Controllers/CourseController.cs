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

namespace EducationPortal.WEB.MVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICourseService service;
        private readonly ISkillService skillService;

        public CourseController(IMapper mapper, ICourseService service, ISkillService skillService)
        {
            this.service = service;
            this.skillService = skillService;
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
            var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var dto = this.mapper.Map<CourseDto>(model);
        
            var courseId = await this.service.Create(Guid.Parse(creatorId), dto);

            var course = await this.service.GetByIdAsync(courseId);

            var courseModel = this.mapper.Map<CourseViewModel>(course);
        
            return RedirectToAction("AddSkills", courseModel);
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddSkills(CourseViewModel model, int page = 1)
        {
            int pageSize = 5;

            var skillsCount = await this.skillService.TotalCountAsync();

            var skills = await this.skillService.GetPageAsync(page, pageSize);

            var pvm = new PageViewModel(skillsCount, page, pageSize);

            var viewModel = new PaginationViewModel<SkillModel>
            {
                PageViewModel = pvm,
                Models = this.mapper.Map<IEnumerable<SkillModel>>(skills)
            };

            return View(new CourseUpdateViewModel
            {
                CourseModel = model,
                Skills = viewModel
            });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSkills(CourseUpdateViewModel model)
        {


            return RedirectToAction("Index");
        }
        
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                await this.service.DeleteAsync(id);
            }

            return RedirectToAction("Index");
        }
    }
}
