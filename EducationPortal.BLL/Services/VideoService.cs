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
        private IMapper mapper;

        public VideoService(IUnitOfWork uow)
        {
            this.Db = uow;

            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<Video, VideoDTO>().ReverseMap()).CreateMapper();
        }

        public void AddVideo(VideoDTO video)
        {
            this.Db.Videos.Create(this.mapper.Map<VideoDTO, Video>(video));
        }

        public VideoDTO GetVideo(Guid id)
        {
            Video video = this.Db.Videos.GetById(id);

            if (video == null)
            {
                return null;
            }
            
            return this.mapper.Map<Video, VideoDTO>(video);
        }

        public List<VideoDTO> AllVideos()
        {
            return this.mapper.Map<IEnumerable<Video>, List<VideoDTO>>(this.Db.Videos.GetAll());
        }
    }
}
