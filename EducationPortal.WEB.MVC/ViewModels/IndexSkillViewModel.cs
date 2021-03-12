using System.Collections.Generic;
using EducationPortal.WEB.MVC.Models;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class IndexSkillViewModel
    {
        public PageViewModel PageViewModel { get; set; }

        public IEnumerable<SkillModel> Skills { get; set; }
    }
}
