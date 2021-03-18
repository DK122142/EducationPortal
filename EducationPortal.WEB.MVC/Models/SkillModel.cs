using System;
using System.Collections.Generic;

namespace EducationPortal.WEB.MVC.Models
{
    public class SkillModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        /// <summary>
        /// Id of Profiles with this skill
        /// </summary>
        public IList<Guid> ProfileSkillsId { get; set; }

        public IEnumerable<Guid> CoursesId { get; set; }
    }
}
