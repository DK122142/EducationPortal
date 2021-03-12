using System.Collections.Generic;
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
            int pageSize = 3;

            var count = await this.service.TotalCount();

            var materials = await this.service.GetPage((page - 1) * pageSize, pageSize);

            var pvm = new PageViewModel(count, page, pageSize);

            var viewModel = new IndexMaterialsViewModel()
            {
                PageViewModel = pvm,
                Materials = this.mapper.Map<IEnumerable<MaterialModel>>(materials)
            };

            return View(viewModel);
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult CreateArticle() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle(ArticleViewModel model)
        {
            await this.service.Add(this.mapper.Map<ArticleDto>(model));

            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult CreateBook() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(BookViewModel model)
        {
            var book = this.mapper.Map<BookDto>(model);
            book.Authors = model.Authors.Split(",");

            await this.service.Add(book);

            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult CreateVideo() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVideo(VideoViewModel model)
        {
            await this.service.Add(this.mapper.Map<VideoDto>(model));

            return RedirectToAction("Index");
        }
    }
}
