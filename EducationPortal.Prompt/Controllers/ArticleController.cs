using System;
using System.Collections.Generic;
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

            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleModel>().ReverseMap())
                .CreateMapper();
        }

        public void AddArticle(ArticleModel model)
        {
            this.service.Add(this.mapper.Map<ArticleModel, ArticleDTO>(model));
        }

        public ArticleModel GetById(Guid id)
        {
            return this.mapper.Map<ArticleDTO, ArticleModel>(this.service.GetById(id));
        }

        public IEnumerable<ArticleModel> GetArticlesOf(AccountModel model)
        {
            return this.mapper.Map<IEnumerable<ArticleDTO>, IEnumerable<ArticleModel>>(
                this.service.Find(a => a.Owner == model.Id));
        }
    }
}
