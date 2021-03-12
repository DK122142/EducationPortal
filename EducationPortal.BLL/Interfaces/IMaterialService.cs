using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.Interfaces
{
    public interface IMaterialService : IService<MaterialDto>
    {
        Task<Material> GetMaterialByName(string materialName);

        Task IncludeMaterialInCourse(string materialId, string courseId);

        Task Add(IEnumerable<Material> items);

        Task<int> Update(IEnumerable<Material> items);
    }
}
