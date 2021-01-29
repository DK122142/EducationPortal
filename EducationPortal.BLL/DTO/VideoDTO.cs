using System;

namespace EducationPortal.BLL.DTO
{
    public class VideoDTO : MaterialDTO
    {
        public string Link { get; set; }

        public string Duration { get; set; }

        public string Quality { get; set; }
    }
}
