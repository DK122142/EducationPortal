using System;
using System.Collections.Generic;

namespace EducationPortal.DAL.Entities
{
    public class Profile : Entity
    {
        public string Name { get; set; }

        //Account
        public Guid Owner { get; set; }

        //List<Material>
        public List<Guid> PassedMaterials { get; set; }

        //List<Dictionary<Skill, int>>
        public List<Dictionary<Guid, int>> SkillsLevels { get; set; }
    }
}
