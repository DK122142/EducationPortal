using System;

namespace EducationPortal.DAL.Entities
{
    public class Video : Material
    {
        public string Link { get; private set; }

        public string Duration { get; private set; }

        public string Quality { get; private set; }


        public Video(Guid id, string name, Guid owner, string link, string duration, string quality)
            : base(id, name, owner)
        {
            
            this.Link = link;
            this.Duration = duration;
            this.Quality = quality;
        }
    }
}
