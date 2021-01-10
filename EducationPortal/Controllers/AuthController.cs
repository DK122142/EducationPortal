using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Entities;
using EducationPortal.Services;

namespace EducationPortal.Controllers
{
    public class AuthController : UserController
    {


        public async Task<User> Login(string login, string password)
        {
            Guid id = storageController.FindRecordByAttribute<User>("Name", login);
            User user = await storageController.GetRecordById<User>(id);
            
            if (PasswordHasher.VerifyHashedPassword(user.Password, password))
            {
                return user;
            }

            return default;
        }
        
        public async Task<User> Register(string login, string password)
        {
            User newUser = new User(Guid.NewGuid(), login, PasswordHasher.HashPassword(password));
            await storageController.AddRow(newUser);
            return newUser;
        }
    }
}
