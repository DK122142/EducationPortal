using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationPortal.Entities;
using EducationPortal.Storage;

namespace EducationPortal.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ITableManager tableManager) : base(tableManager)
        {
            TableManager.StorageController.CreateTable<User>();
        }

        public IEnumerable<Task<Video>> GetVideos(User user)
        {
            var videoIds = TableManager.Where<Video>("Owner", user.Id.ToString());

            if (videoIds.Count == 0)
            {
                return default;
            }

            var videos = videoIds.Select(id => TableManager.WhereId<Video>(id));

            return videos;
        }
    }
}
