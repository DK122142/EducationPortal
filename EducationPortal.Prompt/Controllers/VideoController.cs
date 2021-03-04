using System;
using System.Collections.Generic;
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

        public VideoModel GetById(Guid id)
        {
            return this.mapper.Map<VideoDTO, VideoModel>(this.videoService.GetById(id));
        }

        public void AddVideo(VideoModel model)
        {
            this.videoService.Add(this.mapper.Map<VideoModel, VideoDTO>(model));
        }
        
        public IEnumerable<VideoModel> GetVideosOf(AccountModel model)
        {
            return this.mapper.Map<IEnumerable<VideoDTO>, IEnumerable<VideoModel>>(
                this.videoService.Find(a => a.Owner == model.Id));
        }
    }
}
