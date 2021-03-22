using System;
using System.Collections.Generic;
using System.Security.Claims;
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
    public class MaterialController : Controller
    {
        private readonly IMaterialService materialService;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public MaterialController(IMapper mapper, IMaterialService materialService, ILogger<MaterialController> logger)
        {
            this.mapper = mapper;
            this.materialService = materialService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;

            var count = await this.materialService.TotalCountAsync();

            var materials = await this.materialService.GetPageAsync(page, pageSize);

            var pvm = new PageViewModel(count, page, pageSize);

            var viewModel = new PaginationViewModel<MaterialModel>
            {
                PageViewModel = pvm,
                Models = this.mapper.Map<IEnumerable<MaterialModel>>(materials)
            };

            this.logger.LogInformation($"Opened page {page} of materials");

            return View(viewModel);
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult CreateArticle() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle(ArticleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
                var dto = this.mapper.Map<ArticleDto>(model);

                await this.materialService.Create(Guid.Parse(creatorId),  dto);

                this.logger.LogInformation($"Created article {model.Name}");

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateBook() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(BookCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
                var dto = this.mapper.Map<BookDto>(model);

                await this.materialService.Create(Guid.Parse(creatorId),  dto);
                this.logger.LogInformation($"Created book {model.Name}");

                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult CreateVideo() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVideo(VideoCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var dto = this.mapper.Map<VideoDto>(model);

                await this.materialService.Create(Guid.Parse(creatorId),  dto);
                this.logger.LogInformation($"Created video {model.Name}");

                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> EditArticle(Guid id)
        {
            var material = await this.materialService.GetByIdAsync(id);
            var model = this.mapper.Map<ArticleModel>(material);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditArticle(ArticleModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = this.mapper.Map<ArticleDto>(model);
                    await this.materialService.Edit(dto);
                    
                    this.logger.LogInformation($"Updated article {model.Name}");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> EditBook(Guid id)
        {
            var material = await this.materialService.GetByIdAsync(id);
            var model = this.mapper.Map<BookModel>(material);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBook(BookModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = this.mapper.Map<BookDto>(model);
                    await this.materialService.Edit(dto);
                    this.logger.LogInformation($"Updated book {model.Name}");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> EditVideo(Guid id)
        {
            var material = await this.materialService.GetByIdAsync(id);
            var model = this.mapper.Map<VideoModel>(material);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVideo(VideoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = this.mapper.Map<VideoDto>(model);
                    await this.materialService.Edit(dto);
                    this.logger.LogInformation($"Updated video {model.Name}");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                await this.materialService.DeleteAsync(id);
                this.logger.LogInformation($"Deleted material {id}");
            }

            return RedirectToAction("Index");
        }
    }
}
