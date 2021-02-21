using System;
using System.Collections.Generic;

namespace EducationPortal.DAL.Entities
{
    public class Book : Material
    {
        // Fixed name of property
        public int PageCount { get; set; }

        public List<string> Authors { get; set; }

        public string Format { get; set; }
        
        public DateTime Published { get; set; }

        public override string MaterialType => nameof(Book);
    }
}
