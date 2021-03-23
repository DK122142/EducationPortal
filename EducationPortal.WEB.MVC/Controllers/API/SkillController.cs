using System;
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
    public class SkillController : ControllerBase
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

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var skill = await this.skillService.GetByIdAsync(id);

            if (skill == null)
            {
                return BadRequest();
            }

            return new ObjectResult(skill);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(SkillCreateViewModel skillCreateViewModel)
        {
            var skillDto = this.mapper.Map<SkillDto>(skillCreateViewModel);

            await this.skillService.Create(skillDto);

            this.logger.LogInformation($"Added skill {skillCreateViewModel.Name}");

            return Ok(skillCreateViewModel);
        }
        
        [Authorize]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, SkillModel skillModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var skillDto = this.mapper.Map<SkillDto>(skillModel);
                    await this.skillService.Edit(skillDto);
                }

                return Ok(skillModel);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [Authorize]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.skillService.DeleteAsync(id);
            return Ok();
        }
    }

}
