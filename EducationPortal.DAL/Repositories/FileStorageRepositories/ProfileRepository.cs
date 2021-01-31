using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class ProfileRepository : IRepository<Profile>
    {
        private readonly FSContext _context;

        public ProfileRepository(FSContext context)
        {
            this._context = context;
        }

        public IEnumerable<Profile> GetAll()
        {
            throw new NotImplementedException();
        }

        public Profile Get(Guid id)
        {
            return this._context.Storage.Get<Profile>(id);
        }

        public IEnumerable<Profile> Find(Func<Profile, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Create(Profile item)
        {
            return this._context.Storage.CreateAsync(item);
        }

        public Task Update(Profile item)
        {
            return this._context.Storage.UpdateAsync(item);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
