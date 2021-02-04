using System;

namespace EducationPortal.DAL.Entities
{
    public class Role : Entity
    {
        public Guid Account { get; set; }

        public Roles RoleType { get; set; }

        public string Description { get; set; }
    }
}
