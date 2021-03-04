using System;
using System.Collections.Generic;

namespace EducationPortal.DAL.Entities
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CreatorId { get; set; }

        public Profile Creator { get; set; }
        
        public IList<Material> Materials { get; set; }
        
        public ICollection<Skill> Skills { get; set; }

        public IList<Profile> JoinedProfiles { get; set; }

        public IList<Profile> CompletedProfiles { get; set; }
    }
}
