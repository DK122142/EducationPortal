using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BLL.DTO
{
    public class AccountDTO : EntityDTO
    {
        public string Login { get; set; }
        
        public string Password { get; set; }
        
    }
}
