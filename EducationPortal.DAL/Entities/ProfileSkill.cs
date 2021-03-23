using System;

namespace EducationPortal.DAL.Entities
{
    public class ProfileSkill
    {
        public Guid ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public Guid SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        public int Level { get; set; }
    }
}
