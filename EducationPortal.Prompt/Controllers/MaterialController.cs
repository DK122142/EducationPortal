using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Controllers
{
    public class MaterialController
    {
        
        private IMaterialService service;
        private IMapper mapper;

        public MaterialController(IMaterialService service)
        {
            this.service = service;

            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<MaterialDto, MaterialModel>().ReverseMap())
                .CreateMapper();
        }

        public void Add(MaterialModel model)
        {
            this.service.Add(this.mapper.Map<MaterialDto>(model));
        }

    }
}
