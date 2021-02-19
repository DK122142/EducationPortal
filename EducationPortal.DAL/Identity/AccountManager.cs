using System;
using System.Linq;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;
using EducationPortal.DAL.Infrastructure;

namespace EducationPortal.DAL.Identity
{
    public class AccountManager
    {
        private readonly IContext context;
        private IPasswordHasher passwordHasher;

        public AccountManager(IIdentityContext context)
        {
            this.context = context;
            // TODO rethink/reconstruct
            this.passwordHasher = new PasswordHasher();
        }

        public Account Authenticate(string login, string password)
        {
            Account account = context.Db.Find<Account>(a => a.Login == login).FirstOrDefault();

            if (account == null)
            {
                Console.WriteLine($"Account not found");
                return default;
            }

            if (this.passwordHasher.VerifyHashedPassword(account.Password, password))
            {
                return account;
            }

            return default;
        }
        
        public async Task<Account> Register(string login, string password)
        {
            var exists = context.Db.Any<Account>(a => a.Login == login);

            if(exists)
            {
                Console.WriteLine($"Account with login {login} already exists!");
                return null;
            }

            Account newAccount = new Account {
                Id = Guid.NewGuid(),
                Login = login,
                Password = this.passwordHasher.HashPassword(password)
            };
            
            await context.Db.CreateAsync(newAccount);

            return newAccount;
        }
    }
}
