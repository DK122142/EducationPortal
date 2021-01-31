using System;
using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class CourseDTO : MaterialDTO
    {
        public string Description { get; set; }

        public List<Guid> Materials { get; set; }

        public List<Guid> Skills { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.None;
    }
}
