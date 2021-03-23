using System.ComponentModel.DataAnnotations;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class RegisterViewModel
    {
        
        [Required(ErrorMessage = "Requires username")]
        [Display(Name = "Username")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Requires password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
         
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not match")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
