namespace EducationPortal.BLL.DTO
{
    public class MaterialDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }
        
        public string Discriminator { get; }
    }
}
