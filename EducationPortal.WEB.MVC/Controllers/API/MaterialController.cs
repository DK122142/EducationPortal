using System;
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

namespace EducationPortal.WEB.MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
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
        
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var materialDto = await this.materialService.GetByIdAsync(id);

            if (materialDto == null)
            {
                return BadRequest();
            }

            return new ObjectResult(materialDto);
        }
        
        [Authorize]
        [HttpPost("create-article")]
        public async Task<IActionResult> CreateArticle(ArticleCreateViewModel articleCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
                var articleDto = this.mapper.Map<ArticleDto>(articleCreateViewModel);

                await this.materialService.Create(Guid.Parse(creatorId),  articleDto);

                this.logger.LogInformation($"Created article {articleCreateViewModel.Name}");
                
                return Ok(articleCreateViewModel);
            }

            return BadRequest(articleCreateViewModel);
        }
        
        [Authorize]
        [HttpPost("create-book")]
        public async Task<IActionResult> CreateBook(BookCreateViewModel bookCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
                var bookDto = this.mapper.Map<BookDto>(bookCreateViewModel);

                await this.materialService.Create(Guid.Parse(creatorId),  bookDto);
                this.logger.LogInformation($"Created book {bookCreateViewModel.Name}");

                return Ok(bookCreateViewModel);
            }

            return BadRequest(bookCreateViewModel);
        }
        
        [Authorize]
        [HttpPost("create-video")]
        public async Task<IActionResult> CreateVideo(VideoCreateViewModel videoCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var videoDto = this.mapper.Map<VideoDto>(videoCreateViewModel);

                await this.materialService.Create(Guid.Parse(creatorId),  videoDto);
                this.logger.LogInformation($"Created video {videoCreateViewModel.Name}");

                return Ok(videoCreateViewModel);
            }

            return BadRequest(videoCreateViewModel);
        }
        
        [Authorize]
        [HttpPost("edit-article")]
        public async Task<IActionResult> EditArticle(ArticleModel articleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var articleDto = this.mapper.Map<ArticleDto>(articleModel);
                    await this.materialService.Edit(articleDto);
                    
                    this.logger.LogInformation($"Updated article {articleModel.Name}");
                }

                return Ok(articleModel);
            }
            catch
            {
                return BadRequest(articleModel);
            }
        }
        
        [Authorize]
        [HttpPost("edit-book")]
        public async Task<IActionResult> EditBook(BookModel bookModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bookDto = this.mapper.Map<BookDto>(bookModel);
                    await this.materialService.Edit(bookDto);
                    this.logger.LogInformation($"Updated book {bookModel.Name}");
                }

                return Ok(bookModel);
            }
            catch
            {
                return BadRequest(bookModel);
            }
        }
        
        [Authorize]
        [HttpPost("edit-video")]
        public async Task<IActionResult> EditVideo(VideoModel videoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var videoDto = this.mapper.Map<VideoDto>(videoModel);
                    await this.materialService.Edit(videoDto);
                    this.logger.LogInformation($"Updated video {videoModel.Name}");
                }

                return Ok(videoModel);
            }
            catch
            {
                return BadRequest(videoModel);
            }
        }
        
        [Authorize]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.materialService.DeleteAsync(id);
            return Ok();
        }
    }
}
