using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class BookDTO : MaterialDto
    {
        public int PageCount { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Format { get; set; }
        
        public int PublicationYear { get; set; }
    }
}
