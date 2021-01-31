using System;

namespace EducationPortal.BLL.DTO
{
    public abstract class MaterialDTO : EntityDTO
    {
        public string Name { get; set; }

        public Guid Owner { get; set; }
        
        public abstract MaterialType MaterialType { get; }
    }
}
