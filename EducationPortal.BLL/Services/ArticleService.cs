using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class ArticleService : Service<Article, ArticleDto>, IArticleService
    {
        public ArticleService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
