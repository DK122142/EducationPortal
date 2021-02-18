using System;

namespace EducationPortal.DAL.Entities
{
    public class Article : Material
    {
        public DateTime Published { get; set; }

        public override string MaterialType { get; set; } = "Article";
    }
}
