using System.Collections.Generic;

namespace EducationPortal.Prompt.Models
{
    public class CourseModel : EntityModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        // List<Material>
        public List<string> Materials { get; set; }

        // List<Skill>
        public List<string> Skills { get; set; }
    }
}
