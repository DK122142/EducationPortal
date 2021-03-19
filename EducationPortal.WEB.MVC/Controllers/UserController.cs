using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
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
        private IUserService service;
        private ICourseService courseService;

        public UserController(IMapper mapper, IUserService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = await this.service.GetByIdAsync(Guid.Parse(id));

            return View(new UserViewModel
            {
                Profile = this.mapper.Map<ProfileModel>(profile)
            });
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> JoinToCourse(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.service.JoinToCourse(Guid.Parse(userId), id);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CompleteCourse(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.service.CompleteCourse(Guid.Parse(userId), id);

            return RedirectToAction("Index", "Home");
        }
    }
}
