using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class CourseDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; }

        public IEnumerable<string> MaterialIds { get; set; }

        public IEnumerable<string> SkillNames { get; set; }
    }
}
