using System;
using System.Collections.Generic;
using EducationPortal.WEB.MVC.Models;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class UserViewModel
    {
        public ProfileModel Profile { get; set; }

        public IEnumerable<ProfileSkillModel> ProfileSkills { get; set; }

        public IEnumerable<MaterialModel> PassedMaterials { get; set; }

        public IEnumerable<CourseModel> CompletedCourses { get; set; }

        public IEnumerable<CourseModel> JoinedCourses { get; set; }
    }
}
