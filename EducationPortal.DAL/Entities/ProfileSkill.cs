using System;

namespace EducationPortal.DAL.Entities
{
    public class ProfileSkill
    {
        public string ProfileId { get; set; }

        public Profile Profile { get; set; }

        public Guid SkillId { get; set; }

        public Skill Skill { get; set; }

        public int Level { get; set; }
    }
}
