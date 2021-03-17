using System.Collections.Generic;
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
    }
}
