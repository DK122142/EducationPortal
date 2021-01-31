using System;
using System.Collections.Generic;
using EducationPortal.BLL.DTO;

namespace EducationPortal.BLL.Interfaces
{
    public interface IVideoService
    {
        void AddVideo(VideoDTO video);

        VideoDTO GetVideo(Guid id);

        List<VideoDTO> AllVideos();
    }
}
