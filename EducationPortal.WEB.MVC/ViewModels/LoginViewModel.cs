using System.ComponentModel.DataAnnotations;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Login { get; set; }
         
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
         
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
         
        public string ReturnUrl { get; set; }
    }
}
