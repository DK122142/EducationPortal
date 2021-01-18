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

        protected Material(Guid id, string name) : base(id)
        {
            this.Name = name;
        }
    }
}
