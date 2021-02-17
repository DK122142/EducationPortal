using System;

namespace EducationPortal.BLL.DTO
{
    public class ArticleDTO : MaterialDTO
    {
        public DateTime Published { get; set; }

        public new string MaterialType { get; } = "Article";
    }
}
