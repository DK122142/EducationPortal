using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPortal.DAL.Entities
{
    public class Article : Material
    {
        public DateTime Published { get; set; }
    }
}
