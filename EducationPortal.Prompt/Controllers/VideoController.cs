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

            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<VideoDto, VideoModel>().ReverseMap())
                .CreateMapper();
        }

        public VideoModel GetById(string id)
        {
            return this.mapper.Map<VideoModel>(this.videoService.GetById(id));
        }

        public void AddVideo(VideoModel model)
        {
            this.videoService.Add(this.mapper.Map<VideoModel, VideoDto>(model));
        }
        
        // public IEnumerable<VideoModel> GetVideosOf(AccountModel model)
        // {
        //     return this.mapper.Map<IEnumerable<VideoDto>, IEnumerable<VideoModel>>(
        //         this.videoService.Where(a => a.OwnerId == ""));
        // }
    }
}
