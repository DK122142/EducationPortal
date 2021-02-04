using System;

namespace EducationPortal.Prompt.Models
{
    public class AccountModel : EntityModel
    {
        public string Login { get; set; }
        
        public string Password { get; set;}
        
        public Guid Profile { get; set; }

        public Guid Role { get; set; }
    }
}
