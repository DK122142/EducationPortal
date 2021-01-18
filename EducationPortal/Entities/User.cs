using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EducationPortal.Services;

namespace EducationPortal.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        
        public string Password { get; private set; }

        public User(Guid id, string name, string password) : base(id)
        {
            this.Name = name;
            this.Password = password;
        }
    }
}
