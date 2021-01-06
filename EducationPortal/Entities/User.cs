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
        [JsonInclude]
        public string Name { get; private set; }

        [JsonInclude]
        public string Password { get; private set; }

        public User(Guid id, string name, string password) : base(id)
        {
            Name = name;
            Password = password;
        }
    }
}
