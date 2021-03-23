using System;

namespace EducationPortal.BLL.DTO
{
    public class ProfileSkillDto
    {
        public Guid ProfileId { get; set; }
        
        public Guid SkillId { get; set; }
        
        public string SkillName { get; set; }

        public string SkillDescription { get; set; }

        public int Level { get; set; }
    }
}
