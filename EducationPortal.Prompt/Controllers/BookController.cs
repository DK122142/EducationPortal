using System;
using System.Collections.Generic;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Controllers
{
    public class BookController
    {
        private IBookService service;
        private IMapper mapper;

        public BookController(IBookService service)
        {
            this.service = service;

            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookModel>().ReverseMap())
                .CreateMapper();
        }

        public BookModel GetById(Guid id)
        {
            return this.mapper.Map<BookDTO, BookModel>(this.service.GetById(id));
        }

        public void AddBook(BookModel model)
        {
            this.service.Add(this.mapper.Map<BookModel, BookDTO>(model));
        }
        
        public IEnumerable<BookModel> GetBooksOf(AccountModel model)
        {
            return this.mapper.Map<IEnumerable<BookDTO>, IEnumerable<BookModel>>(
                this.service.Find(a => a.Owner == model.Id));
        }
    }
}
