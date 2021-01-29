using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Entities
{
    public class Course : Material
    {
        public string Name { get; }

        public Guid Owner { get; }
        
        public List<Article> Articles { get; }

        public List<Book> Books { get; }

        public List<Video> Videos { get; }

        public Course(Guid id, string name, Guid owner, List<Article> articles, List<Book> books, List<Video> videos)
            : base(id, name, owner)
        {
            this.Articles = articles;
            this.Books = books;
            this.Videos = videos;
        }
    }
}
