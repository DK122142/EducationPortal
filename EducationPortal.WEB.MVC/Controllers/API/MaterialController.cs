using System;
using System.Security.Claims;
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
        private IMaterialService materialService;
        private IMapper mapper;

        public MaterialController(IMapper mapper, IMaterialService materialService)
        {
            this.mapper = mapper;
            this.materialService = materialService;
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


        

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.materialService.DeleteAsync(id);
            return Ok();
        }
    }
}
