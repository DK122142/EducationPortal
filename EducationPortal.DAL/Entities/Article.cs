using System;

namespace EducationPortal.DAL.Entities
{
    public class Article : Material
    {
        public string Link { get; set; }

        public DateTime Published { get; set; }
    }
}
