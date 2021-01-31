using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Entities
{
    public class Course : Material
    {
        public List<Article> Articles { get; set; }

        public List<Book> Books { get; set; }

        public List<Video> Videos { get; set; }
    }
}
