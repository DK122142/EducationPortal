using System;

namespace EducationPortal.Prompt.Models
{
    public class AccountModel : EntityModel
    {
        public string Login { get; set; }
        
        public string Password { get; set;}

        // Profile
        public Guid Profile { get; set; }
    }
}
