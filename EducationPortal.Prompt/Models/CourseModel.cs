using System;
using System.Collections.Generic;

namespace EducationPortal.Prompt.Models
{
    public class CourseModel : MaterialModel
    {
        public string Description { get; set; }

        //List<Material>
        public List<Guid> Materials { get; set; }

        //List<Skill>
        public List<Guid> Skills { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.None;
    }
}
