using System;

namespace EducationPortal.Prompt.Models
{
    public class ArticleModel : MaterialModel
    {
        public DateTime Published { get; set; }

        public override string MaterialType => "Article";
    }
}
