using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private FSContext context;

        public CourseRepository(FSContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<Course> GetAll()
        {
            return this.context.Storage.GetAll<Course>();
        }

        public Course Get(Guid id)
        {
            return this.context.Storage.Get<Course>(id);
        }

        public IEnumerable<Course> Find(Func<Course, bool> predicate)
        {
            return this.context.Storage.Find(predicate);
        }

        public Task Create(Course item)
        {
            return this.context.Storage.CreateAsync(item);
        }

        public Task Update(Guid id, Course item)
        {
            return this.context.Storage.UpdateAsync(id, item);
        }

        public void Delete(Guid id)
        {
            this.context.Storage.Delete<Course>(id);
        }
    }
}
