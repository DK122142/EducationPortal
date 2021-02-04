using System;

namespace EducationPortal.Prompt.Models
{
    public class ArticleModel : MaterialModel
    {
        public DateTime Published { get; set; }

        public string Link { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.Article;
    }
}
