using System;

namespace EducationPortal.DAL.Entities
{
    public abstract class Material : Entity
    {
        public string Name { get; set; }

        // Account
        public Guid Owner { get; set; }

        public abstract MaterialType MaterialType { get; }
    }
}
