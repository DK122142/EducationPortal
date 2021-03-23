using System.Collections.Generic;

namespace EducationPortal.DAL.Entities
{
    public class Book : Material
    {
        public int PageCount { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Format { get; set; }
        
        public int PublicationYear { get; set; }
    }
}
