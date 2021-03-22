using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPortal.DAL.Entities
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public virtual Profile Creator { get; set; }
        
        public virtual IList<Material> Materials { get; set; }
        
        public virtual ICollection<Skill> Skills { get; set; }

        public virtual IList<Profile> JoinedProfiles { get; set; }

        public virtual IList<Profile> CompletedProfiles { get; set; }
    }
}
