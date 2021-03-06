using System;

namespace EducationPortal.BLL.DTO
{
    public abstract class MaterialDTO : EntityDto
    {
        public string Name { get; set; }

        // Account
        public Guid Owner { get; set; }

        public abstract string MaterialType { get; }

        // Can be Null
        public string Source { get; set; }
    }
}
