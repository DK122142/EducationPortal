using System;

namespace EducationPortal.Prompt.Models
{
    public abstract class MaterialModel : EntityModel
    {
        public string Name { get; set; }

        public Guid Owner { get; set; }

        public abstract MaterialType MaterialType { get; }
    }
}
