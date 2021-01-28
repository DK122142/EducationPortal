using System;

namespace EducationPortal.DAL.Entities
{
    public class Account : Entity
    {
        public string Login { get; }
        
        public string Password { get; }

        public Account(Guid id, string login, string password) : base(id)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
