using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Entities
{
    public class CourseSkill
    {
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}
