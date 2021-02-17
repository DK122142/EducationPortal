using System;

namespace EducationPortal.Prompt.Models
{
    public class ArticleModel : MaterialModel
    {
        public DateTime Published { get; set; }

        public new string MaterialType { get; } = "Article";
    }
}
