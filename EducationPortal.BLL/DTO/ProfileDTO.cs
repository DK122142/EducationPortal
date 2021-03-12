using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class ProfileDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AccountUserName { get; set; }
        
        public virtual IEnumerable<string> SkillsId { get; set; }

        public virtual IEnumerable<string> PassedMaterialsId { get; set; }
        
        // public virtual IEnumerable<string> CreatedCoursesId { get; set; }
        
        public IEnumerable<string> CompletedCoursesNames { get; set; }

        public IEnumerable<string> JoinedCoursesNames { get; set; }
    }
}
