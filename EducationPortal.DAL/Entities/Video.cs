namespace EducationPortal.DAL.Entities
{
    public class Video : Material
    {
        public string Link { get; set; }

        public string Duration { get; set; }

        public string Quality { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.Video;
    }
}
