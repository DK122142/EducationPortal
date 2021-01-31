using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Prompt.Models
{
    public class ArticleModel : MaterialModel
    {
        public DateTime Published { get; set; }

        public string Link { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.Article;
    }
}
