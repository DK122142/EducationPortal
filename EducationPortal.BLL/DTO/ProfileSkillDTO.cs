using System;

namespace EducationPortal.BLL.DTO
{
    public class ProfileSkillDto
    {
        public Guid ProfileId { get; set; }

        public Guid SkillId { get; set; }

        public int Level { get; set; }
    }
}
