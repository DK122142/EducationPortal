using System;

namespace EducationPortal.BLL.DTO
{
    public class RoleDTO : EntityDTO
    {
        public Guid Account { get; set; }

        public Roles RoleType { get; set; }

        public string Description { get; set; }
    }
}
