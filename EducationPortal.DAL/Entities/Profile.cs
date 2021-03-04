using System;
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

        public IList<ProfileSkill> ProfileSkills { get; set; }

        public ICollection<Material> PassedMaterials { get; set; }
        
        public IList<Course> CreatedCourses { get; set; }
        
        public ICollection<Course> CompletedCourses { get; set; }

        public ICollection<Course> JoinedCourses { get; set; }

        public Account Account { get; set; }
    }
}
