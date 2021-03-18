using System;
using Microsoft.AspNetCore.Identity;

namespace EducationPortal.DAL.Entities
{
    public class Account : IdentityUser<Guid>
    {
        public virtual Profile Profile { get; set; }
    }
}
