using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.WEB.MVC.Models;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class IndexSkillViewModel
    {
        public PageViewModel PageViewModel { get; set; }

        public IEnumerable<SkillModel> Skills { get; set; }
    }
}
