using System;

namespace EducationPortal.DAL.Entities
{
    public class Article : Material
    {
        public DateTime Published { get; set; }

        public string Link { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.Article;
    }
}
