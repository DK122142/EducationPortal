using System;
using System.Collections.Generic;

namespace EducationPortal.DAL.Entities
{
    public class Book : Material
    {
        public int Pages { get; set; }

        public List<string> Authors { get; set; }

        public string Format { get; set; }
        
        public DateTime Published { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.Book;
    }
}
