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
            int pageSize = 3;

            var skillsCount = await this.service.TotalCount();

            var skills = await this.service.GetPage((page - 1) * pageSize, pageSize);

            var pvm = new PageViewModel(skillsCount, page, pageSize);

            var viewModel = new IndexSkillViewModel
            {
                PageViewModel = pvm,
                Skills = this.mapper.Map<IEnumerable<SkillModel>>(skills)
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
        public async Task<IActionResult> Create(SkillViewModel model)
        {
            await this.service.Add(this.mapper.Map<SkillDto>(model));

            this.logger.LogInformation($"Added skill {model.Name}");

            return RedirectToAction("Index");
        }
    }
}
