using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EducationPortal.Entities
{
    public abstract class Entity
    {
        [JsonInclude]
        public Guid Id { get; }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
