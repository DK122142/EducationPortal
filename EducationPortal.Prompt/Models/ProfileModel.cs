using System;
using System.Collections.Generic;

namespace EducationPortal.Prompt.Models
{
    public class ProfileModel : EntityModel
    {
        public string Name { get; set; }

        //Account
        public string Owner { get; set; }

        //List<Material>
        public List<string> PassedMaterials { get; set; }
        
        // Maybe change to Dictionary<Course, @status>
        public List<string> CompletedCourses { get; set; }

        public List<string> InProgressCourses { get; set; }

        //Dictionary<Skill, int>
        public Dictionary<string, int> SkillsLevels { get; set; }
    }
}
