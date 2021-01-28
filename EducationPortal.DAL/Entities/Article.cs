using System;

namespace EducationPortal.DAL.Entities
{
    public class Article : Material
    {
        public string Link { get; }

        public DateTime Published { get; }

        public Article(Guid id, string name, Guid owner, string link, DateTime published) : base(id, name, owner)
        {
            this.Link = link;
            this.Published = published;
        }
    }
}
