using System;
using System.Collections.Generic;
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
            var id = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var profile = await this.service.GetByIdAsync(id);
            
            var joinedCourses = await this.service.JoinedCourses(id);
            var completedCourses = await this.service.CompletedCourses(id);
            var materials = await this.service.LearnedMaterials(id);
            var skills = await this.service.ProfileSkills(id);
            
            var jcModels = this.mapper.Map<List<CourseModel>>(joinedCourses);
            var ccModels = this.mapper.Map<List<CourseModel>>(completedCourses);
            var mModels = this.mapper.Map<List<MaterialModel>>(materials);
            var sModels = this.mapper.Map<List<ProfileSkillModel>>(skills);

            return View(new UserViewModel
            {
                Profile = this.mapper.Map<ProfileModel>(profile),
                CompletedCourses = ccModels,
                JoinedCourses = jcModels,
                PassedMaterials = mModels,
                ProfileSkills = sModels
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
