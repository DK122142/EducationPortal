using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPortal.DAL.Entities
{
    public class Profile
    {
        [Key]
        [ForeignKey(nameof(Entities.Account))]
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual IList<ProfileSkill> ProfileSkills { get; set; }

        public virtual IEnumerable<Material> AddedMaterials { get; set; }

        public virtual ICollection<Material> PassedMaterials { get; set; }
        
        public virtual IList<Course> CreatedCourses { get; set; }
        
        public virtual ICollection<Course> CompletedCourses { get; set; }

        public virtual ICollection<Course> JoinedCourses { get; set; }

        public virtual Account Account { get; set; }
    }
}
