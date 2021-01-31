using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Prompt.Models
{
    public class VideoModel : MaterialModel
    {
        public string Link { get; set; }

        public string Duration { get; set; }

        public string Quality { get; set; }

        public override MaterialType MaterialType { get; } = MaterialType.Video;
    }
}
