using System;
using System.Collections.Generic;
using EducationPortal.WEB.MVC.Models;

namespace EducationPortal.WEB.MVC.ViewModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CreatorId { get; set; }

        public IEnumerable<MaterialModel> Materials { get; set; }

        public IEnumerable<SkillModel> Skills { get; set; }

        public IEnumerable<ProfileModel> JoinedProfiles { get; set; }

        public IEnumerable<ProfileModel> CompletedProfiles { get; set; }
    }
}
