using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Controllers
{
    public class ArticleController
    {
        private IArticleService service;
        private IMapper mapper;

        public ArticleController(IArticleService service)
        {
            this.service = service;

            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDto, ArticleModel>().ReverseMap())
                .CreateMapper();
        }

        public async Task AddArticle(ArticleModel model)
        {
            var tmp = this.mapper.Map<ArticleDto>(model);
            await this.service.Add(tmp);
        }

        public ArticleModel GetById(string id)
        {
            return this.mapper.Map<ArticleModel>(this.service.GetById(id));
        }

        // public IEnumerable<ArticleModel> GetArticlesOf(AccountModel model)
        // {
        //     return this.mapper.Map<IEnumerable<ArticleDto>, IEnumerable<ArticleModel>>(
        //         this.service.Where(a => a.OwnerId == model.ProfileId));
        // }
    }
}
