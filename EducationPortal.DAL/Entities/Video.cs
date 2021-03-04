using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPortal.DAL.Entities
{
    [Table("Videos")]
    public class Video : Material
    {
        public string Duration { get; set; }

        public string Quality { get; set; }
    }
}
