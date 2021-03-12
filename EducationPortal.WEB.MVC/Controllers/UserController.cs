using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.WEB.MVC.Models;
using EducationPortal.WEB.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace EducationPortal.WEB.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IMapper mapper;
        private IUserService userService;
        private ICourseService courseService;

        public UserController(IMapper mapper, IUserService userService, ICourseService courseService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = await this.userService.GetById(id);

            return View(new UserViewModel
            {
                Profile = this.mapper.Map<ProfileModel>(profile)
            });
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> JoinToCourse(string id)
        {
            await this.userService.JoinToCourse(User.FindFirst(ClaimTypes.NameIdentifier).Value,
                await this.courseService.GetById(id));

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CompleteCourse(string id)
        {
            await this.userService.CompleteCourse(User.FindFirst(ClaimTypes.NameIdentifier).Value,
                await this.courseService.GetById(id));

            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public IActionResult CreateCourse() => RedirectToAction("Create", "Course");
        
        [HttpPost]
        public IActionResult AddMaterial() => RedirectToAction("Index", "Material");
        
        [HttpPost]
        public IActionResult CreateSkill() => RedirectToAction("Create", "Skill");
    }
}
