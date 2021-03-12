using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.BLL.Services
{
    public class MaterialService : Service<Material, MaterialDto>, IMaterialService
    {
        public MaterialService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public async Task<Material> GetMaterialByName(string materialName)
        {
            return await this.repository.Single(m => m.Name.Equals(materialName));
        }

        public async Task IncludeMaterialInCourse(string materialId, string courseId)
        {
            var material = await this.GetById(materialId);

            if (material.IncludedInId == null)
            {
                material.IncludedInId = new List<string>();
            }

            var included = material.IncludedInId.ToList();
            included.Add(courseId);

            material.IncludedInId = included;

            await this.Update(material);

            return;
        }

        public async Task Add(IEnumerable<Material> items)
        {
            await this.repository.Add(items);
            await this.uow.Commit();
        }

        public async Task<int> Update(IEnumerable<Material> items)
        {
            this.repository.Update(items);
            return await this.uow.Commit();
        }
    }
}
