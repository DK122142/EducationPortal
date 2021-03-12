using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.WEB.MVC.Models;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class IndexMaterialsViewModel
    {
        public PageViewModel PageViewModel { get; set; }

        public IEnumerable<MaterialModel> Materials { get; set; }
    }
}
