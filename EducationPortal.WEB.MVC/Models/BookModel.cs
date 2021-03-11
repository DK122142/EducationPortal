using System.Collections.Generic;

namespace EducationPortal.WEB.MVC.Models
{
    public class BookModel : MaterialModel
    {
        public int PageCount { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Format { get; set; }
        
        public int PublicationYear { get; set; }
    }
}
