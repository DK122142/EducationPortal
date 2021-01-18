using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EducationPortal.Storage;

namespace EducationPortal.Entities
{
    public abstract class Entity : IStorageEntity
    {
        public Guid Id { get; }

        protected Entity(Guid id)
        {
            this.Id = id;
        }
    }
}
