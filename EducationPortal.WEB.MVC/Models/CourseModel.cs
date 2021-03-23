﻿using System;
using System.Collections.Generic;

namespace EducationPortal.WEB.MVC.Models
{
    public class CourseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CreatorId { get; set; }

        public IEnumerable<Guid> MaterialsId { get; set; }

        public IEnumerable<Guid> SkillsId { get; set; }

        public IEnumerable<Guid> JoinedProfilesId { get; set; }

        public IEnumerable<Guid> CompletedProfilesId { get; set; }
    }
}
