using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.BLL.Services
{
    public class Service<TEntity, TDto> : IService<TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, new()
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public Service(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = new Startup().ConfigureServices().GetRequiredService<IMapper>();
        }

        public async Task Add(TDto entity)
        {
            var newEntity = this.mapper.Map<TEntity>(entity);

            if (string.IsNullOrEmpty(newEntity.Id))
            {
                newEntity.Id = Guid.NewGuid().ToString();
            }

            await this.uow.Repository<TEntity>().Add(newEntity);
            await this.uow.Commit();
        }

        public Task Add(IEnumerable<TDto> items)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TDto>> All()
        {
            throw new NotImplementedException();
        }

        public async Task<TDto> GetById(string id)
        {
            var result = await this.uow.Repository<TEntity>().GetById(id);
            return this.mapper.Map<TDto>(result);
        }

        void IService<TDto>.Update(TDto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TDto> items)
        {
            throw new NotImplementedException();
        }

        public void Delete(TDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<TDto> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TDto> Where(Expression<Func<TDto, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
