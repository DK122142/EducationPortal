using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPortal.DAL.Entities
{
    [Table("Books")]
    public class Book : Material
    {
        public int PageCount { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Format { get; set; }
        
        public int PublicationYear { get; set; }
    }
}
