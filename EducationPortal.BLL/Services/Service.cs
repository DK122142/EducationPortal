using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class Service<TEntity, TDto> : IService<TDto>
        where TEntity : class
        where TDto : class
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly IMapper mapper;

        protected Service(IRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDto>> GetPageAsync(int pageNumber, int itemsOnPage)
        {
            var page = await this.repository.SkipTake((pageNumber - 1) * itemsOnPage, itemsOnPage);

            return this.mapper.Map<IEnumerable<TDto>>(page);
        }

        public virtual async Task<TDto> GetByIdAsync(Guid id)
        {
            var entity = await this.repository.GetByIdAsync(id);

            return this.mapper.Map<TDto>(entity);
        }

        public virtual async Task<IEnumerable<TDto>> FindBy(Expression<Func<TDto, bool>> predicate)
        {
            var expr = this.mapper.Map<Expression<Func<TEntity, bool>>>(predicate);

            var entity = await this.repository.FindBy(expr);

            return this.mapper.Map<IEnumerable<TDto>>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await this.repository.GetByIdAsync(id);

            this.repository.Delete(entity);

            await this.repository.SaveChangesAsync();
        }

        public async Task<int> TotalCountAsync()
        {
            return await this.repository.CountAsync();
        }
    }
}
