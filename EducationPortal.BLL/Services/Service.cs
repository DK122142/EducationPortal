using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class Service<TEntity, TDto> : IService<TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, new()
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly IMapper mapper;

        protected Service(IRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task Add(TDto entity)
        {
            var newEntity = this.mapper.Map<TEntity>(entity);

            if (newEntity.Id != Guid.Empty)
            {
                newEntity.Id = Guid.NewGuid();
            }

            await this.repository.Add(newEntity);
            await this.uow.Commit();
        }

        public async Task Add(IEnumerable<TDto> items)
        {
            // TODO
            // var enti
            // await this.repository.Add();
            await this.uow.Commit();
        }

        public async Task<IList<TDto>> All()
        {
            return this.mapper.Map<IList<TDto>>(await this.repository.All());
        }

        public async Task<TDto> GetById(Guid id)
        {
            return this.mapper.Map<TDto>(await this.repository.GetById(id));
        }

        public async Task Update(TDto entity)
        {
            this.repository.Update(this.mapper.Map<TEntity>(entity));
            await this.uow.Commit();
        }

        public async Task Update(IEnumerable<TDto> items)
        {
            this.repository.Update(this.mapper.Map<IEnumerable<TEntity>>(items));
            await this.uow.Commit();
        }

        public void Delete(TDto entity)
        {
            this.repository.Delete(this.mapper.Map<TEntity>(entity));
            this.uow.Commit();
        }

        public void Delete(IEnumerable<TDto> entities)
        {
            this.repository.Delete(this.mapper.Map<IEnumerable<TEntity>>(entities));
            this.uow.Commit();
        }

        public IQueryable<TDto> Where(Expression<Func<TDto, bool>> expression) =>
            this.mapper.Map<IQueryable<TDto>>(
                this.repository.Where(this.mapper.Map<Expression<Func<TEntity, bool>>>(expression)));

        public async Task<TDto> Single(Expression<Func<TDto, bool>> expression)
        {
            return this.mapper.Map<TDto>(
                await this.repository.Single(this.mapper.Map<Expression<Func<TEntity, bool>>>(expression)));
        }

        public async Task<IEnumerable<TDto>> GetPage(int skip, int take)
        {
            return this.mapper.Map<IEnumerable<TDto>>(await this.repository.GetPage(skip, take));
        }

        public async Task<int> TotalCount() => await this.repository.TotalCount();

        public Task<int> Save() => this.uow.Commit();
    }
}
