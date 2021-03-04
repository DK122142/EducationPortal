namespace EducationPortal.Prompt.Models
{
    public class VideoModel : MaterialModel
    {
        public string Duration { get; set; }

        public string Quality { get; set; }

        public override string MaterialType => "Video";
    }
}
