using System;
using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class ProfileDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AccountUserName { get; set; }
        
        public virtual IEnumerable<Guid> SkillsId { get; set; }

        public virtual IEnumerable<Guid> PassedMaterialsId { get; set; }
        
        public virtual IEnumerable<Guid> CreatedCoursesId { get; set; }
        
        public IEnumerable<Guid> CompletedCoursesId { get; set; }

        public IEnumerable<Guid> JoinedCoursesId { get; set; }
    }
}
