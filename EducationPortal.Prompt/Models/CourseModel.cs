using System.Collections.Generic;

namespace EducationPortal.Prompt.Models
{
    public class CourseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; }

        public IEnumerable<string> MaterialIds { get; set; }

        public IEnumerable<string> SkillNames { get; set; }
    }
}
