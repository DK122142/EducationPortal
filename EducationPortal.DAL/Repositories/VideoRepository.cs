using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories
{
    public class VideoRepository : IRepository<Video>
    {
        private EducationPortalContext dbContext;

        public VideoRepository(EducationPortalContext context)
        {
            this.dbContext = context;
        }

        public IEnumerable<Video> GetAll()
        {
            return this.dbContext.Storage.GetAll<Video>();
        }

        public Video Get(Guid id)
        {
            return dbContext.Storage.Get<Video>(id);
        }

        public IEnumerable<Video> Find(Func<Video, bool> predicate)
        {
            return dbContext.Storage.Find(predicate);
        }

        public Task Create(Video item)
        {
            return dbContext.Storage.CreateAsync(item);
        }

        public Task Update(Guid old, Video newVideo)
        {
            return dbContext.Storage.UpdateAsync(old, newVideo);
        }

        public void Delete(Guid id)
        {
            dbContext.Storage.Delete<Video>(id);
        }
    }
}
