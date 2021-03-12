using System.Collections.Generic;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.DTO
{
    public class SkillDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public IList<string> ProfileSkillsId { get; set; }

        public IEnumerable<string> CoursesId { get; set; }
    }
}
