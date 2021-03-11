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
        protected readonly IUnitOfWork uow;
        protected readonly IRepository<TEntity> repository;
        protected readonly IMapper mapper;

        protected Service(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.repository = this.uow.Repository<TEntity>();
            this.mapper = mapper;
        }

        public async Task Add(TDto entity)
        {
            var newEntity = this.mapper.Map<TEntity>(entity);

            if (string.IsNullOrEmpty(newEntity.Id))
            {
                newEntity.Id = Guid.NewGuid().ToString();
            }

            await this.repository.Add(newEntity);
            await this.uow.Commit();
        }

        public async Task Add(IEnumerable<TDto> items)
        {
            await this.repository.Add(this.mapper.Map<IEnumerable<TEntity>>(items));
            await this.uow.Commit();
        }

        public async Task<IList<TDto>> All()
        {
            return this.mapper.Map<IList<TDto>>(await this.repository.All());
        }

        public async Task<TDto> GetById(string id)
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

        public async Task<IEnumerable<TDto>> GetPage(int skip, int take) =>
            this.mapper.Map<IEnumerable<TDto>>(await this.repository.GetPage(skip, take));

        public async Task<int> TotalCount() => await this.repository.TotalCount();
    }
}
