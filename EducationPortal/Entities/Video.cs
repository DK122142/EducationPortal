using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entities
{
    public class Video : Material
    {
        public string Link { get; private set; }

        public string Duration { get; private set; }

        public string Quality { get; private set; }


        public Video(Guid id, string name, string link, string duration, string quality) : base(id, name)
        {
            this.Link = link;
            this.Duration = duration;
            this.Quality = quality;
        }
    }
}
