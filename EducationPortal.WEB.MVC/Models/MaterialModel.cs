using System.Collections.Generic;

namespace EducationPortal.WEB.MVC.Models
{
    public class MaterialModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }

        public IEnumerable<string> PassedByUsersId { get; set; }

        public IEnumerable<string> IncludedInId { get; set; }
        
        public string Discriminator { get; set; }
    }
}
