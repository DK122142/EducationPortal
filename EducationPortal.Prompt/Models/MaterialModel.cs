using System;

namespace EducationPortal.Prompt.Models
{
    public abstract class MaterialModel : EntityModel
    {
        public string Name { get; set; }

        // Account
        public Guid Owner { get; set; }

        public abstract string MaterialType { get; set; }

        // Can be Null
        public string Source { get; set; }
    }
}
