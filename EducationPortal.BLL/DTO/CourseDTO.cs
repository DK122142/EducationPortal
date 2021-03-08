using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class CourseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; }

        public List<string> MaterialNames { get; set; }

        public List<string> SkillNames { get; set; }
    }
}
