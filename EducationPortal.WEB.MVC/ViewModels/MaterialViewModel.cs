using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class MaterialViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }
        
        public string Discriminator { get; set; }
    }
}
