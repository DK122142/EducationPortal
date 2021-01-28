using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories
{
    public class UserRepository : IRepository<Account>
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

        public Task Update(Guid id, Account item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
