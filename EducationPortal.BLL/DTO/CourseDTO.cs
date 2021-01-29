using System;
using System.Collections.Generic;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.DTO
{
    public class CourseDTO : MaterialDTO
    {
        public string Name { get; set; }

        public Guid Owner { get; set; }
        
        public List<BLL.DTO.ArticleDTO> Articles { get; set; }

        public List<BookDTO> Books { get; set; }

        public List<VideoDTO> Videos { get; set; }
    }
}
