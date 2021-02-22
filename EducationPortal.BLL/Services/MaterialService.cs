using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class MaterialService<TMaterial, TMaterialDTO> : IMaterialService<TMaterialDTO>
        where TMaterial : Material
        where TMaterialDTO : MaterialDTO
    {
        private readonly IUnitOfWork db;
        private readonly IMapper mapper;

        public MaterialService(IUnitOfWork uow)
        {
            this.db = uow;

            this.mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TMaterial, TMaterialDTO>().ReverseMap();
                })
                .CreateMapper();
        }

        public async Task AddMaterial(TMaterialDTO material)
        {
            await this.GetRepositoryByType(material.MaterialType)
                .Create(this.mapper.Map<TMaterialDTO, TMaterial>(material));
        }

        public IEnumerable<TMaterialDTO> GetAllMaterials()
        {
            return this.mapper.Map<IEnumerable<TMaterial>, IEnumerable<TMaterialDTO>>(
                this.GetRepositoryByType(this.GetMaterialType()).GetAll());
        }

        public TMaterialDTO GetMaterialById(Guid id)
        {
            var material = this.GetRepositoryByType(this.GetMaterialType()).GetById(id);

            if (material != null)
            {
                return this.mapper.Map<TMaterial, TMaterialDTO>(material);
            }

            return default;
        }

        public IEnumerable<TMaterialDTO> FindMaterial(Func<TMaterialDTO, bool> predicate)
        {
            return this.mapper.Map<IEnumerable<TMaterial>, IEnumerable<TMaterialDTO>>(this
                .GetRepositoryByType(this.GetMaterialType())
                .Find(this.mapper.Map<Func<TMaterialDTO, bool>, Func<TMaterial, bool>>(predicate)));
        }

        public async Task UpdateMaterial(TMaterialDTO material)
        {
            await this.GetRepositoryByType(material.MaterialType)
                .Update(this.mapper.Map<TMaterialDTO, TMaterial>(material));
        }

        public void DeleteMaterial(Guid id)
        {
            this.GetRepositoryByType(this.GetMaterialType()).Delete(id);
        }

        
        private IRepository<TMaterial> GetRepositoryByType(string type)
        {
            switch (type)
            {
                case nameof(Article):
                    return this.db.Articles as IRepository<TMaterial>;
                case nameof(Book):
                    return this.db.Books as IRepository<TMaterial>;
                case nameof(Video):
                    return this.db.Videos as IRepository<TMaterial>;
                default:
                    return default;
            }
        }

        private string GetMaterialType()
        {
            return typeof(TMaterial).GetProperty("MaterialType").GetValue(new object() as TMaterial) as string;
        }
    }
}
