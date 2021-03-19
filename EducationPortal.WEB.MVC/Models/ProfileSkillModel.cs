using System;

namespace EducationPortal.WEB.MVC.Models
{
    public class ProfileSkillModel
    {
        public Guid ProfileId { get; set; }
        
        public Guid SkillId { get; set; }
        
        public string SkillName { get; set; }

        public string SkillDescription { get; set; }

        public int Level { get; set; }
    }
}
