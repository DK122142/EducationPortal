using System;

namespace EducationPortal.Prompt.Models
{
    public class RoleModel : EntityModel
    {
        public Guid Account { get; set; }

        public Prompt.Models.Roles RoleType { get; set; }

        public string Description { get; set; }
    }
}
