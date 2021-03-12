using System.Collections.Generic;
using EducationPortal.WEB.MVC.Models;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class IndexCoursesViewModel
    {
        public PageViewModel PageViewModel { get; set; }

        public IEnumerable<CourseModel> Courses { get; set; }
    }
}
