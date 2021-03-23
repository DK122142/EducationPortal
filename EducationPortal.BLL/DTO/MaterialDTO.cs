using System;
using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class MaterialDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }

        public Guid AddedById { get; set; }

        public IEnumerable<Guid> PassedByUsersId { get; set; }

        public IEnumerable<Guid> IncludedInCoursesId { get; set; }
        
        public string Discriminator { get; set; }
    }
}
