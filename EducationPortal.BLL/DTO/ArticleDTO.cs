using System;

namespace EducationPortal.BLL.DTO
{
    public class ArticleDTO : MaterialDTO
    {
        public string Link { get; set; }

        public DateTime Published { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.Article;
    }
}
