using System;
using Microsoft.AspNetCore.Identity;

namespace EducationPortal.DAL.Entities
{
    public class Account : IdentityUser
    {
        public Profile Profile { get; set; }
    }
}
