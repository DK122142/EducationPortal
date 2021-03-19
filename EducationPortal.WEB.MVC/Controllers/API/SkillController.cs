using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.WEB.MVC.Models;
using EducationPortal.WEB.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EducationPortal.WEB.MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private IMapper mapper;
        private ISkillService service;
        private ILogger logger;

        public SkillController(IMapper mapper, ISkillService service, ILogger<Controllers.SkillController> logger)
        {
            this.mapper = mapper;
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var skill = await this.service.GetByIdAsync(id);

            if (skill == null)
            {
                return BadRequest();
            }

            return new ObjectResult(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SkillCreateViewModel model)
        {
            var dto = this.mapper.Map<SkillDto>(model);

            await this.service.Create(dto);

            this.logger.LogInformation($"Added skill {model.Name}");

            return Ok(model);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, SkillModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = this.mapper.Map<SkillDto>(model);
                    await this.service.Edit(dto);
                }

                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.service.DeleteAsync(id);
            return Ok();
        }
    }

}
