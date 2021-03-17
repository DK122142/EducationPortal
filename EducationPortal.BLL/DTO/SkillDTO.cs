using System;
using System.Collections.Generic;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.DTO
{
    public class SkillDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public IList<Guid> ProfileSkillsId { get; set; }

        public IEnumerable<Guid> CoursesId { get; set; }
    }
}
