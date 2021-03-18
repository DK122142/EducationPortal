using System;
using System.Collections.Generic;
using EducationPortal.WEB.MVC.Models;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class CourseUpdateViewModel
    {
        public CourseViewModel CourseModel { get; set; }

        public PaginationViewModel<MaterialModel> Materials { get; set; }

        public PaginationViewModel<SkillModel> Skills { get; set; }
        
        // public string SkillSearchString { get; set; }
        //
        // public string MaterialSearchString { get; set; }
    }
}
