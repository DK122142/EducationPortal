using System;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Controllers
{
    public class VideoController
    {
        private IVideoService VideoService => ServiceModule.ServiceProvider.GetRequiredService<IVideoService>();

        VideoModel GetVideo(Guid id)
        {
            VideoDTO video = this.VideoService.GetVideo(id);
            
            if (video == null)
            {
                return null;
            }

            return new VideoModel
            {
                Id = video.Id,
                Name = video.Name,
                Owner = video.Owner,
                Duration = video.Duration,
                Source = video.Duration,
                Quality = video.Quality
            };
        }

        public void AddVideo(VideoModel model)
        {
            VideoDTO newVideo = new VideoDTO
            {
                Id = model.Id,
                Name = model.Name,
                Owner = model.Owner,
                Duration = model.Duration,
                Source = model.Source,
                Quality = model.Quality
            };

            this.VideoService.AddVideo(newVideo);
        }



    }
}
