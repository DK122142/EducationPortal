using System;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using Profile = EducationPortal.DAL.Entities.Profile;

namespace EducationPortal.BLL.Services
{
    public class MaterialService : Service<Material, MaterialDto>, IMaterialService
    {
        private IRepository<Profile> profileRepository;

        public MaterialService(IRepository<Material> repository, IRepository<Profile> profileRepository, IMapper mapper) : base(repository, mapper)
        {
            this.profileRepository = profileRepository;
        }

        public async Task Create(Guid creatorId, MaterialDto material)
        {
            material.Id = Guid.NewGuid();

            var entity = this.mapper.Map<Material>(material);

            var profile = await this.profileRepository.FindAsync(creatorId);

            entity.AddedBy = profile;
            
            await this.repository.AddAsync(entity);

            await this.repository.SaveChangesAsync();
        }

        public async Task Edit(MaterialDto material)
        {
            var entity = this.mapper.Map<Material>(material);

            this.repository.Update(entity);

            await this.repository.SaveChangesAsync();
        }
    }
}
