namespace EducationPortal.DAL.Entities
{
    public class ProfileSkill
    {
        public string ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public string SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        public int Level { get; set; }
    }
}
