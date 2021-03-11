namespace EducationPortal.WEB.MVC.Models
{
    public class MaterialModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }
        
        public string Discriminator { get; }
    }
}
