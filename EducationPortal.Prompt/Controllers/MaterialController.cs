using System.Threading.Tasks;
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

            this.mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MaterialDto, MaterialModel>().ReverseMap();
                    cfg.CreateMap<ArticleDto, ArticleModel>().ReverseMap();
                })
                .CreateMapper();
        }

        public async Task Add<TMaterialModel, TMaterialDto>(TMaterialModel model)
            where TMaterialModel: MaterialModel
            where TMaterialDto: MaterialDto
        {
            await this.service.Add(this.mapper.Map<TMaterialDto>(model));
        }

    }
}
