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

namespace EducationPortal.WEB.MVC.Controllers
{
    public class MaterialController : Controller
    {
        private IMaterialService service;
        private IMapper mapper;

        public MaterialController(IMapper mapper, IMaterialService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;

            var count = await this.service.TotalCountAsync();

            var materials = await this.service.GetPageAsync(page, pageSize);

            var pvm = new PageViewModel(count, page, pageSize);

            var viewModel = new PaginationViewModel<MaterialModel>
            {
                PageViewModel = pvm,
                Models = this.mapper.Map<IEnumerable<MaterialModel>>(materials)
            };

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
            var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var dto = this.mapper.Map<ArticleDto>(model);

            await this.service.Create(Guid.Parse(creatorId),  dto);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateBook() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(BookCreateViewModel model)
        {
            var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var dto = this.mapper.Map<BookDto>(model);

            await this.service.Create(Guid.Parse(creatorId),  dto);

            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult CreateVideo() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVideo(VideoCreateViewModel model)
        {
            var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dto = this.mapper.Map<VideoDto>(model);

            await this.service.Create(Guid.Parse(creatorId),  dto);

            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditArticle(Guid id)
        {
            var material = await this.service.GetByIdAsync(id);
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
        [HttpGet]
        public async Task<IActionResult> EditBook(Guid id)
        {
            var material = await this.service.GetByIdAsync(id);
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
        [HttpGet]
        public async Task<IActionResult> EditVideo(Guid id)
        {
            var material = await this.service.GetByIdAsync(id);
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
