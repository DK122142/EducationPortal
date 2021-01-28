using System;

namespace EducationPortal.DAL.Entities
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
