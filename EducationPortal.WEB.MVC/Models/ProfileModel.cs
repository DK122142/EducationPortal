using System.Collections.Generic;

namespace EducationPortal.WEB.MVC.Models
{
    public class ProfileModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AccountUserName { get; set; }
        
        public IEnumerable<string> SkillsId { get; set; }

        public IEnumerable<string> PassedMaterialsId { get; set; }
        
        // public virtual IEnumerable<string> CreatedCoursesId { get; set; }

        public IEnumerable<string> CompletedCoursesNames { get; set; }

        public IEnumerable<string> JoinedCoursesNames { get; set; }
    }
}
