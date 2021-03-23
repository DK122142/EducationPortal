using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.Interfaces;
using EducationPortal.WEB.MVC.Models;
using EducationPortal.WEB.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.WEB.MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }


        [HttpGet("profile")]
        [Authorize]
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

            return new ObjectResult(new UserViewModel
            {
                Profile = this.mapper.Map<ProfileModel>(profile),
                CompletedCourses = completedCoursesModels,
                JoinedCourses = joinedCoursesModels,
                PassedMaterials = materialModels,
                ProfileSkills = profileSkillModels
            });
        }

        [Authorize]
        [HttpPost("jointocourse/{id:Guid}")]
        public async Task<IActionResult> JoinToCourse(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.userService.JoinToCourse(Guid.Parse(userId), id);

            return Ok();
        }

        [Authorize]
        [HttpPost("completecourse/{id:Guid}")]
        public async Task<IActionResult> CompleteCourse(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.userService.CompleteCourse(Guid.Parse(userId), id);

            return Ok();
        }
    }
}
