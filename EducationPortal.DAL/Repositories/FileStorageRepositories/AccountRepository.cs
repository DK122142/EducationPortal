using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class AccountRepository : IRepository<Account>
    {
        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> Find(Func<Account, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Create(Account item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Account item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
