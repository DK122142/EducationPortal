using System.Collections.Generic;

namespace EducationPortal.WEB.MVC.Models
{
    public class SkillModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public IList<string> ProfileSkillsId { get; set; }

        public IEnumerable<string> CoursesId { get; set; }
    }
}
