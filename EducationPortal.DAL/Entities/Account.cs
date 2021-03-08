using EducationPortal.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EducationPortal.DAL.Entities
{
    public class Account : IdentityUser, IEntity
    {
        public virtual Profile Profile { get; set; }
    }
}
