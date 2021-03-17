using System;
using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class CourseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; }

        public IEnumerable<string> MaterialNames { get; set; }

        public IEnumerable<string> SkillNames { get; set; }

        public IEnumerable<string> JoinedProfilesId { get; set; }

        public IEnumerable<string> CompletedProfilesId { get; set; }
    }
}
