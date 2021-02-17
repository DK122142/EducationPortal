namespace EducationPortal.BLL.DTO
{
    public class VideoDTO : MaterialDTO
    {
        public string Duration { get; set; }

        public string Quality { get; set; }

        public new string MaterialType { get; } = "Video";
    }
}
