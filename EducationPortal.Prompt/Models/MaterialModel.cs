using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Prompt.Models
{
    public abstract class MaterialModel : EntityModel
    {
        public string Name { get; set; }

        public Guid Owner { get; set; }
    }
}
