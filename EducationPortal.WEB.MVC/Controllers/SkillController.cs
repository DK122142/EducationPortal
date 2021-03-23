using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.WEB.MVC.Models;
using EducationPortal.WEB.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EducationPortal.WEB.MVC.Controllers
{
    public class SkillController : Controller
    {
        private readonly IMapper mapper;
        private readonly ISkillService skillService;
        private readonly ILogger logger;

        public SkillController(IMapper mapper, ISkillService skillService, ILogger<SkillController> logger)
        {
            this.mapper = mapper;
            this.skillService = skillService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;

            var skillsCount = await this.skillService.TotalCountAsync();

            var skills = await this.skillService.GetPageAsync(page, pageSize);

            var pageViewModel = new PageViewModel(skillsCount, page, pageSize);

            var viewModel = new PaginationViewModel<SkillModel>
            {
                PageViewModel = pageViewModel,
                Models = this.mapper.Map<IEnumerable<SkillModel>>(skills)
            };
            
            this.logger.LogInformation($"Opened page {page} of skills");

            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillCreateViewModel skillCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var skillDto = this.mapper.Map<SkillDto>(skillCreateViewModel);

                await this.skillService.Create(skillDto);

                this.logger.LogInformation($"Added skill {skillCreateViewModel.Name}");

                return RedirectToAction("Index");
            }

            return View(skillCreateViewModel);
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var skill = await this.skillService.GetByIdAsync(id);
            var model = this.mapper.Map<SkillModel>(skill);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SkillModel skillModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var skillDto = this.mapper.Map<SkillDto>(skillModel);
                    await this.skillService.Edit(skillDto);

                    this.logger.LogInformation($"Updated skill {skillModel.Name}");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(skillModel);
            }
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                await this.skillService.DeleteAsync(id);

                this.logger.LogInformation($"Deleted skill {id}");
            }

            return RedirectToAction("Index");
        }
    }
}
