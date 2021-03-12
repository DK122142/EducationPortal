using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class CourseViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; }

        public IEnumerable<string> MaterialIds { get; set; }

        public IEnumerable<string> SkillIds { get; set; }
    }
}
