using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPortal.DAL.Entities
{
    [Table("Articles")]
    public class Article : Material
    {
        public DateTime Published { get; set; }
    }
}
