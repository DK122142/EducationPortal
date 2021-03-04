using System;
using System.Collections.Generic;

namespace EducationPortal.Prompt.Models
{
    public class BookModel : MaterialModel
    {
        public int PageCount { get; set; }

        public List<string> Authors { get; set; }

        public string Format { get; set; }
        
        public DateTime Published { get; set; }

        public override string MaterialType => "Book";
    }
}
