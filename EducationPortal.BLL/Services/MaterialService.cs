// using System;
// using System.Collections.Generic;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
// using AutoMapper;
// using AutoMapper.Extensions.ExpressionMapping;
// using EducationPortal.BLL.DTO;
// using EducationPortal.BLL.Interfaces;
// using EducationPortal.DAL.Entities;
// using EducationPortal.DAL.Interfaces;
//
// namespace EducationPortal.BLL.Services
// {
//     public class MaterialService<TMaterial, TMaterialDTO> : IMaterialService<TMaterialDTO>
//         where TMaterial : Material, new()
//         where TMaterialDTO : MaterialDTO, new()
//     {
//         private readonly IUnitOfWork uow;
//         private readonly IMapper mapper;
//
//         public MaterialService(IUnitOfWork uow)
//         {
//             this.uow = uow;
//
//             this.mapper = new MapperConfiguration(cfg =>
//                 {
//                     cfg.CreateMap<TMaterial, TMaterialDTO>().ReverseMap();
//                     cfg.AddExpressionMapping();
//                 })
//                 .CreateMapper();
//         }
//
//         public async Task Add(TMaterialDTO material)
//         {
//             await this.GetRepositoryByType(material.MaterialType)
//                 .Add(this.mapper.Map<TMaterialDTO, TMaterial>(material));
//         }
//
//         public IEnumerable<TMaterialDTO> GetAll()
//         {
//             return this.mapper.Map<IEnumerable<TMaterial>, IEnumerable<TMaterialDTO>>(
//                 this.GetRepositoryByType(this.GetMaterialType()).All());
//         }
//
//         public TMaterialDTO GetById(Guid id)
//         {
//             var material = this.GetRepositoryByType(this.GetMaterialType()).GetById(id);
//
//             if (material != null)
//             {
//                 return this.mapper.Map<TMaterial, TMaterialDTO>(material);
//             }
//
//             return default;
//         }
//
//         public IEnumerable<TMaterialDTO> Find(Expression<Func<TMaterialDTO, bool>> predicate)
//         {
//             return this.mapper.Map<IEnumerable<TMaterial>, IEnumerable<TMaterialDTO>>(this
//                 .GetRepositoryByType(this.GetMaterialType())
//                 .Where(this.mapper.Map<Expression<Func<TMaterialDTO, bool>>, Expression<Func<TMaterial, bool>>>(
//                     predicate)));
//         }
//
//         public async Task Update(TMaterialDTO material)
//         {
//             await this.GetRepositoryByType(material.MaterialType)
//                 .Update(this.mapper.Map<TMaterialDTO, TMaterial>(material));
//         }
//
//         public void Delete(Guid id)
//         {
//             this.GetRepositoryByType(this.GetMaterialType()).Delete(id);
//         }
//
//         private IRepository<TMaterial> GetRepositoryByType(string type)
//         {
//             switch (type)
//             {
//                 case nameof(Article):
//                     return this.uow.GetRepositoryOfEntity<Article>() as IRepository<TMaterial>;
//                 case nameof(Book):
//                     return this.uow.GetRepositoryOfEntity<Book>() as IRepository<TMaterial>;
//                 case nameof(Video):
//                     return this.uow.GetRepositoryOfEntity<Video>() as IRepository<TMaterial>;
//                 default:
//                     return default;
//             }
//         }
//
//         private string GetMaterialType()
//         {
//             return typeof(TMaterial).GetProperty("MaterialType").GetValue(new TMaterial()) as string;
//         }
//     }
// }
