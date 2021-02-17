namespace EducationPortal.DAL.Entities
{
    public class Video : Material
    {
        // Link changed to Source in Material

        public string Duration { get; set; }

        public string Quality { get; set; }

        public new string MaterialType { get; } = "Video";
    }
}
