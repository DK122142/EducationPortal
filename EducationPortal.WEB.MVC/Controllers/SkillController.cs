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
        private IMapper mapper;
        private ISkillService service;
        private ILogger logger;

        public SkillController(IMapper mapper, ISkillService service, ILogger<SkillController> logger)
        {
            this.mapper = mapper;
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;

            var skillsCount = await this.service.TotalCountAsync();

            var skills = await this.service.GetPageAsync(page, pageSize);

            var pvm = new PageViewModel(skillsCount, page, pageSize);

            var viewModel = new PaginationViewModel<SkillModel>
            {
                PageViewModel = pvm,
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
        public async Task<IActionResult> Create(SkillCreateViewModel model)
        {
            var dto = this.mapper.Map<SkillDto>(model);

            await this.service.Create(dto);

            this.logger.LogInformation($"Added skill {model.Name}");

            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var skill = await this.service.GetByIdAsync(id);
            var model = this.mapper.Map<SkillModel>(skill);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SkillModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = this.mapper.Map<SkillDto>(model);
                    await this.service.Edit(dto);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                await this.service.DeleteAsync(id);
            }

            return RedirectToAction("Index");
        }
    }
}
