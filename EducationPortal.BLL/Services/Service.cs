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

        public virtual async Task<IEnumerable<TDto>> GetPage(int pageNumber, int itemsOnPage)
        {
            var page = await this.repository.SkipTakeToListAsync((pageNumber - 1) * itemsOnPage, itemsOnPage);

            return this.mapper.Map<IEnumerable<TDto>>(page);
        }

        public virtual async Task<TDto> GetById(Guid id)
        {
            var entity = await this.repository.FindAsync(id);

            return this.mapper.Map<TDto>(entity);
        }

        public virtual IQueryable<TDto> FindBy(Expression<Func<TDto, bool>> predicate)
        {
            var expr = this.mapper.Map<Expression<Func<TEntity, bool>>>(predicate);

            var entity = this.repository.FindBy(expr);

            return this.mapper.Map<IQueryable<TDto>>(entity);
        }

        public virtual async Task Delete(Guid id)
        {
            var entity = await this.repository.FindAsync(id);

            this.repository.Delete(entity);

            await this.repository.SaveChangesAsync();
        }
    }
}
