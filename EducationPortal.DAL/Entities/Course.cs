using System;
using System.Collections.Generic;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Entities
{
    public class Course : IEntity
    {
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
