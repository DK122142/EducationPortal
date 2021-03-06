using System.Collections.Generic;

namespace EducationPortal.DAL.Entities
{
    public class Material
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }
        
        public virtual Profile AddedBy { get; set; }

        public virtual IEnumerable<Profile> PassedByUsers { get; set; }

        public virtual IEnumerable<Course> IncludedIn { get; set; }
    }
}
