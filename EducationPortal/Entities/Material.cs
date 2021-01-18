using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entities
{
    public abstract class Material : Entity
    {
        public string Name { get; private set; }

        public Guid Owner { get; private set; }

        protected Material(Guid id, string name, Guid owner) : base(id)
        {
            this.Name = name;
            this.Owner = owner;
        }
    }
}
