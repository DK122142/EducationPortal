using System;

namespace EducationPortal.DAL.Entities
{
    public class Article : Material
    {
        public DateTime Published { get; set; }

        public new string MaterialType { get; } = "Article";
    }
}
