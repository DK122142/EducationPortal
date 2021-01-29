using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;

namespace EducationPortal.BLL.Interfaces
{
    public interface IVideoService
    {
        void AddVideo(VideoDTO video);

        VideoDTO GetVideo(Guid id);
    }
}
