using System;

namespace EducationPortal.BLL.DTO
{
    public class ArticleDTO : MaterialDTO
    {
        public DateTime Published { get; set; }

        public override string MaterialType { get; set; } = "Article";
    }
}
