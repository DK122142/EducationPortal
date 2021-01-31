using System;

namespace EducationPortal.DAL.Entities
{
    public abstract class Material : Entity
    {
        public string Name { get; set; }

        public Guid Owner { get; set; }
    }
}
