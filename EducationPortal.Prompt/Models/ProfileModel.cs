using System;
using System.Collections.Generic;

namespace EducationPortal.Prompt.Models
{
    public class ProfileModel : EntityModel
    {
        public string Name { get; set; }

        //Account
        public Guid Owner { get; set; }

        //List<Material>
        public List<Guid> PassedMaterials { get; set; }
        
        // Maybe change to Dictionary<Course, @status>
        public List<Guid> CompletedCourses { get; set; }

        public List<Guid> InProgressCourses { get; set; }

        //Dictionary<Skill, int>
        public Dictionary<Guid, int> SkillsLevels { get; set; }
    }
}
