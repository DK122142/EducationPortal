using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class SkillRepository : IRepository<Skill>
    {
        private readonly FSContext _context;

        public SkillRepository(FSContext context)
        {
            this._context = context;
        }

        public IEnumerable<Skill> GetAll()
        {
            throw new NotImplementedException();
        }

        public Skill Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skill> Find(Func<Skill, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Create(Skill item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Skill item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
