using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class VideoService : IVideoService
    {
        private IUnitOfWork Db { get; set; }

        public VideoService(IUnitOfWork uow)
        {
            this.Db = uow;
        }

        public void AddVideo(VideoDTO video)
        {
            Video newVideo = new Video(Guid.NewGuid(), video.Name, video.Owner, video.Link, video.Duration,
                video.Quality);

            this.Db.Videos.Create(newVideo);
        }

        public VideoDTO GetVideo(Guid id)
        {
            Video video = this.Db.Videos.Get(id);

            if (video == null)
            {
                return null;
            }

            return new VideoDTO
            {
                Id = video.Id,
                Name = video.Name,
                Owner = video.Owner,
                Duration = video.Duration,
                Link = video.Duration,
                Quality = video.Quality
            };
        }
    }
}
