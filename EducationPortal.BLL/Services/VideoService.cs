using System;
using System.Collections.Generic;
using AutoMapper;
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
            Video newVideo = new Video{
                Id = Guid.NewGuid(), 
                Name = video.Name,
                Owner = video.Owner,
                Source = video.Source,
                Duration = video.Duration,
                Quality = video.Quality
            };

            this.Db.Videos.Create(newVideo);
        }

        public VideoDTO GetVideo(Guid id)
        {
            Video video = this.Db.Videos.GetById(id);

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
                Source = video.Source,
                Quality = video.Quality
            };
        }

        public List<VideoDTO> AllVideos()
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Video, VideoDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Video>, List<VideoDTO>>(this.Db.Videos.GetAll());
        }
    }
}
