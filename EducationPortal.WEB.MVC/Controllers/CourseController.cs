using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.Interfaces;
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

        public CourseController(IMapper mapper, ICourseService courseService)
        {
            this.courseService = courseService;
            this.mapper = mapper;
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
    }
}
