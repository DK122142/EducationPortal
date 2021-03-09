namespace EducationPortal.Prompt.Models
{
    public class MaterialModel : EntityModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }
        
        public string Discriminator { get; set; }
    }
}
