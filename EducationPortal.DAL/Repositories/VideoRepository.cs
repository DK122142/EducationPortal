using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories
{
    public class VideoRepository : IRepository<Video>
    {
        private FSContext context;

        public VideoRepository(FSContext context)
        {
            this.context = context;
        }

        public IEnumerable<Video> GetAll()
        {
            return this.context.Storage.GetAll<Video>();
        }

        public Video Get(Guid id)
        {
            return context.Storage.Get<Video>(id);
        }

        public IEnumerable<Video> Find(Func<Video, bool> predicate)
        {
            return context.Storage.Find(predicate);
        }

        public Task Create(Video item)
        {
            return context.Storage.CreateAsync(item);
        }

        public Task Update(Guid old, Video newVideo)
        {
            return context.Storage.UpdateAsync(old, newVideo);
        }

        public void Delete(Guid id)
        {
            context.Storage.Delete<Video>(id);
        }
    }
}
