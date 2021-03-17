using System;
using EducationPortal.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EducationPortal.DAL.Entities
{
    public class Account : IdentityUser<Guid>, IEntity
    {
        public virtual Profile Profile { get; set; }
    }
}
