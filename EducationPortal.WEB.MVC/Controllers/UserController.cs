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
using Microsoft.Extensions.Logging;

namespace EducationPortal.WEB.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly ILogger logger;

        public UserController(IMapper mapper, IUserService userService, ILogger<UserController> logger)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var id = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var profile = await this.userService.GetByIdAsync(id);
            
            var joinedCoursesDto = await this.userService.JoinedCourses(id);
            var completedCoursesDto = await this.userService.CompletedCourses(id);
            var learnedMaterialsDto = await this.userService.LearnedMaterials(id);
            var profileSkillsDto = await this.userService.ProfileSkills(id);
            
            var joinedCoursesModels = this.mapper.Map<List<CourseModel>>(joinedCoursesDto.Value);
            var completedCoursesModels = this.mapper.Map<List<CourseModel>>(completedCoursesDto.Value);
            var materialModels = this.mapper.Map<List<MaterialModel>>(learnedMaterialsDto.Value);
            var profileSkillModels = this.mapper.Map<List<ProfileSkillModel>>(profileSkillsDto.Value);

            this.logger.LogInformation($"Opened profile of {profile.Name}");

            return View(new UserViewModel
            {
                Profile = this.mapper.Map<ProfileModel>(profile),
                CompletedCourses = completedCoursesModels,
                JoinedCourses = joinedCoursesModels,
                PassedMaterials = materialModels,
                ProfileSkills = profileSkillModels
            });
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> JoinToCourse(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.userService.JoinToCourse(Guid.Parse(userId), id);

            this.logger.LogInformation($"User {userId} joined to course {id}");

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CompleteCourse(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.userService.CompleteCourse(Guid.Parse(userId), id);

            this.logger.LogInformation($"User {userId} completed course {id}");

            return RedirectToAction("Index", "Home");
        }
    }
}
