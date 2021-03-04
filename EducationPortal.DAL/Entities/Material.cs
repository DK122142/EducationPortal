using System;
using System.Collections.Generic;

namespace EducationPortal.DAL.Entities
{
    public class Material
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }
        
        public Profile AddedBy { get; set; }

        public IEnumerable<Profile> PassedByUsers { get; set; }

        public IEnumerable<Course> IncludedIn { get; set; }
    }
}
