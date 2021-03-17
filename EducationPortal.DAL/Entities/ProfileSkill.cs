using System;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Entities
{
    public class ProfileSkill : IEntity
    {
        public Guid ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public Guid Id { get; set; }

        public virtual Skill Skill { get; set; }

        public int Level { get; set; }
    }
}
