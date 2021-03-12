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
            var materials = new List<MaterialDto>();

            foreach (var materialName in model.Materials.Split(","))
            {
                materials.Add(await this.materialService.Single(m=> m.Name.Equals(materialName)));
            }

            var skills = new List<SkillDto>();

            foreach (var skillName in model.Skills.Split(","))
            {
                skills.Add(await this.skillService.Single(m=> m.Name.Equals(skillName)));
            }

            var course = this.mapper.Map<CourseModel>(model);
            course.MaterialIds = new List<string>(materials.Select(m => m.Id));
            course.SkillIds = new List<string>(skills.Select(s => s.Id));
            // course.CreatorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.courseService.Add(this.mapper.Map<CourseDto>(course));

            return RedirectToAction("Index");
        }
    }
}
