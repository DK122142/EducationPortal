using System;
using System.Linq;
using System.Threading.Tasks;
using EducationPortal.Entities;
using EducationPortal.Services;
using EducationPortal.Storage;

namespace EducationPortal.Controllers
{
    public class AuthController : UserController
    {
        public AuthController(ITableManager tableManager) : base(tableManager)
        {
            
        }

        public async Task<User> Login(string login, string password)
        {
            Guid id = TableManager.Where<User>("Name", login).FirstOrDefault();
            User user = await TableManager.WhereId<User>(id);
            
            if (PasswordHasher.VerifyHashedPassword(user.Password, password))
            {
                return user;
            }

            return default;
        }
        
        public async Task<User> Register(string login, string password)
        {
            if (TableManager.AnyEqual<User>("Name", login))
            {
                Console.WriteLine($"User with name(login) {login} already exists!");
                return null;
            }

            User newUser = new User(Guid.NewGuid(), login, PasswordHasher.HashPassword(password));
            await TableManager.StorageController.InsertInto(newUser);
            return newUser;
        }
    }
}
