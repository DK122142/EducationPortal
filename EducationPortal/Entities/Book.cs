using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entities
{
    public class Book : Material
    {
        public int Pages { get; }
        
        public DateTime Published { get; }

        public List<string> Authors { get; }

        public Book(Guid id, string name, Guid owner, int pages, DateTime published, List<string> authors) : base(id,
            name, owner)
        {
            this.Pages = pages;
            this.Published = published;
            this.Authors = authors;
        }
    }
}
