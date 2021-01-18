using System;
using System.Threading.Tasks;
using EducationPortal.Entities;
using EducationPortal.Storage;

namespace EducationPortal.Controllers
{
    public class VideoController : MaterialController
    {
        public VideoController(ITableManager tableManager) : base(tableManager)
        {
            TableManager.StorageController.CreateTable<Video>();
        }

        public async Task<Video> AddVideo(string name, Guid owner, string link, string duration, string quality)
        {
            var video = new Video(Guid.NewGuid(), name, owner, link, duration, quality);

            if (await AddMaterial(video) == null)
            {
                Console.WriteLine($"Video with name {video.Name} already exists!");
                return null;
            }

            return video;
        }
    }
}
