using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.WEB.MVC.Models;
using EducationPortal.WEB.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.WEB.MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IMaterialService service;
        private IMapper mapper;

        public MaterialController(IMapper mapper, IMaterialService service)
        {
            this.mapper = mapper;
            this.service = service;
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
        public async Task<IActionResult> Post(MaterialViewModel model)
        {
            var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dto = this.mapper.Map<MaterialDto>(model);

            await this.service.Create(Guid.Parse(creatorId), dto);
            
            return Ok(model);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, MaterialModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = this.mapper.Map<MaterialDto>(model);
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
