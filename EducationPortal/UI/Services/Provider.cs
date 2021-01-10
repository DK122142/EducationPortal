using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Entities;

namespace EducationPortal.UI.Services
{
    public static class Provider
    {
        public static User AuthorizedUser { get; set; } = default;
    }
}
