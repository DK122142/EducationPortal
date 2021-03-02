using System;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Controllers
{
    public class VideoController
    {
        private IVideoService videoService;
        private IMapper mapper;

        public VideoController(IVideoService videoService)
        {
            this.videoService = videoService;

            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<VideoDTO, VideoModel>().ReverseMap())
                .CreateMapper();
        }

        VideoModel GetVideo(Guid id)
        {
            VideoDTO video = this.videoService.GetById(id);
            
            if (video == null)
            {
                return null;
            }

            return this.mapper.Map<VideoDTO, VideoModel>(video);
        }

        public void AddVideo(VideoModel model)
        {
            this.videoService.Add(this.mapper.Map<VideoModel, VideoDTO>(model));
        }
    }
}
