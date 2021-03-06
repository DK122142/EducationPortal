using Microsoft.AspNetCore.Identity;

namespace EducationPortal.DAL.Entities
{
    public class Account : IdentityUser
    {
        public virtual Profile Profile { get; set; }
    }
}
