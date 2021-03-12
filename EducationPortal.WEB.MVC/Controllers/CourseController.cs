using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Services;
using EducationPortal.WEB.MVC.Models;
using EducationPortal.WEB.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.WEB.MVC.Controllers
{
    public class CourseController : Controller
    {
        private IMapper mapper;
        private ICourseService courseService;
        private IMaterialService materialService;
        private ISkillService skillService;

        public CourseController(IMapper mapper, ICourseService courseService, IMaterialService materialService, ISkillService skillService)
        {
            this.courseService = courseService;
            this.mapper = mapper;
            this.materialService = materialService;
            this.skillService = skillService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;

            var count = await this.courseService.TotalCount();

            var materials = await this.courseService.GetPage((page - 1) * pageSize, pageSize);

            var pvm = new PageViewModel(count, page, pageSize);

            var viewModel = new IndexCoursesViewModel
            {
                PageViewModel = pvm,
                Courses = this.mapper.Map<IEnumerable<CourseModel>>(materials)
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create() => View();

        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            var course = this.mapper.Map<CourseDto>(this.mapper.Map<CourseModel>(model));

            course.Id = Guid.NewGuid().ToString();
            course.MaterialNames = model.Materials.Split(",");
            course.SkillNames = model.Skills.Split(",");

            await this.courseService.CreateCourse(course);
            
            return RedirectToAction("Index");
        }
    }
}
