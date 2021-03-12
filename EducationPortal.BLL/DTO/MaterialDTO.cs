using System.Collections.Generic;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.DTO
{
    public class MaterialDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }

        public IEnumerable<string> PassedByUsersId { get; set; }

        public IEnumerable<string> IncludedInId { get; set; }
        
        public string Discriminator { get; set; }
    }
}
