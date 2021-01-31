using System;
using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class BookDTO : MaterialDTO
    {
        public int Pages { get; set; }
        
        public DateTime Published { get; set; }

        public List<string> Authors { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.Book;
    }
}
