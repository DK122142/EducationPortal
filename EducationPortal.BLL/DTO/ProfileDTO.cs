﻿using System;
using System.Collections.Generic;

namespace EducationPortal.BLL.DTO
{
    public class ProfileDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AccountUserName { get; set; }
        
        public IEnumerable<Guid> ProfileSkillsId { get; set; }
        
        public IEnumerable<Guid> AddedMaterialsId { get; set; }

        public IEnumerable<Guid> PassedMaterialsId { get; set; }
        
        public IEnumerable<Guid> CreatedCoursesId { get; set; }
        
        public IEnumerable<Guid> CompletedCoursesId { get; set; }

        public IEnumerable<Guid> JoinedCoursesId { get; set; }
    }
}
