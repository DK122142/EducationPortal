using System;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using Profile = EducationPortal.DAL.Entities.Profile;

namespace EducationPortal.BLL.Services
{
    public class MaterialService : Service<Material, MaterialDto>, IMaterialService
    {
        private readonly IRepository<Profile> profileRepository;

        public MaterialService(IRepository<Material> repository, IRepository<Profile> profileRepository, IMapper mapper) : base(repository, mapper)
        {
            this.profileRepository = profileRepository;
        }

        public async Task<ResultDetails<Guid>> Create(Guid creatorId, MaterialDto material)
        {
            try
            {
                material.Id = Guid.NewGuid();

                var entity = this.mapper.Map<Material>(material);

                var profile = await this.profileRepository.FindAsync(creatorId);

                entity.AddedBy = profile;
            
                await this.repository.AddAsync(entity);

                await this.repository.SaveChangesAsync();

                return new ResultDetails<Guid>(true, value: entity.Id);
            }
            catch
            {
                return new ResultDetails<Guid>(false);
            }
        }

        public async Task<ResultDetails<Guid>> Edit(MaterialDto material)
        {
            try
            {
                var entity = this.mapper.Map<Material>(material);

                this.repository.Update(entity);

                await this.repository.SaveChangesAsync();

                return new ResultDetails<Guid>(true, value: entity.Id);
            }
            catch
            {
                return new ResultDetails<Guid>(false);
            }
        }
    }
}
