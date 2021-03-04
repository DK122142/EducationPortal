using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Entities
{
    public class ProfileSkill
    {
        public string ProfileId { get; set; }

        public Profile Profile { get; set; }

        public string SkillId { get; set; }

        public Skill Skill { get; set; }

        public int Level { get; set; }
    }
}
