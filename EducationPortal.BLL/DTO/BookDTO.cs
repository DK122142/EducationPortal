using System;
using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class BookDTO : MaterialDTO
    {
        public int PageCount { get; set; }

        public List<string> Authors { get; set; }

        public string Format { get; set; }
        
        public DateTime Published { get; set; }

        public new string MaterialType { get; } = "Book";
    }
}
