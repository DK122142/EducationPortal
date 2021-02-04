using System;

namespace EducationPortal.DAL.Entities
{
    public class Account : Entity
    {
        public string Login { get; set; }
        
        public string Password { get; set; }

        // Profile
        public Guid Profile { get; set; }
    }
}
