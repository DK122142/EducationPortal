using AutoMapper;
using EducationPortal.BLL.Interfaces;
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

        [HttpGet]
        [Authorize]
        public IActionResult Create() => View();
    }
}
