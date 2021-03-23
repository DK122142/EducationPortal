using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPortal.DAL.Entities
{
    public class Material
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }

        public virtual Profile AddedBy { get; set; }

        public virtual IEnumerable<Profile> PassedByUsers { get; set; }

        public virtual IEnumerable<Course> IncludedInCourses { get; set; }

        public string Discriminator { get; set; }
    }
}
