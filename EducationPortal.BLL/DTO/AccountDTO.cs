using System;

namespace EducationPortal.BLL.DTO
{
    public class AccountDTO
    {
        public string Login { get; set; }
        
        public string Password { get; set; }

        public Guid Profile { get; set; }

        public Guid Role { get; set; }
    }
}
