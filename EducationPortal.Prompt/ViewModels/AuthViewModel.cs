using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Prompt.ViewModels
{
    public class AuthViewModel
    {
        
        [Required(ErrorMessage = "Requires username")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Requires password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not match")]
        public string ConfirmPassword { get; set; }
    }
}
