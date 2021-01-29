using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BLL.DTO
{
    public abstract class MaterialDTO : EntityDTO
    {
        public string Name { get; set; }

        public Guid Owner { get; set; }
    }
}
