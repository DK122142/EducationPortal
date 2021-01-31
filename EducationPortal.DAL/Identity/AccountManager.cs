using System;
using System.Linq;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.Infrastructure;

namespace EducationPortal.DAL.Identity
{
    public class AccountManager
    {
        private IdentityContext db;

        public AccountManager(IdentityContext context)
        {
            this.db = context;
        }

        public Account Authenticate(string login, string password)
        {
            Account account = db.Storage.Find<Account>(a => a.Login == login).FirstOrDefault();

            if (account == null)
            {
                Console.WriteLine($"Account not found");
                return default;
            }

            if (PasswordHasher.VerifyHashedPassword(account.Password, password))
            {
                return account;
            }

            return default;
        }
        
        public async Task<Account> Register(string login, string password)
        {
            var exists = db.Storage.Find<Account>(a => a.Login == login).Any();

            if(exists)
            {
                Console.WriteLine($"Account with login {login} already exists!");
                return null;
            }

            Account newAccount = new Account {
                Id = Guid.NewGuid(),
                Login = login,
                Password = PasswordHasher.HashPassword(password),
                Profile = Guid.NewGuid()
            };
            
            await db.Storage.CreateAsync(newAccount);

            return newAccount;
        }
    }
}
