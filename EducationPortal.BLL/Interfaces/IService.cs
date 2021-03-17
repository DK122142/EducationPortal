using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BLL.Interfaces
{
    public interface IService<TDto>
        where TDto : class
    {
        Task<IEnumerable<TDto>> GetPage(int pageNumber, int itemsOnPage);
    }
}
