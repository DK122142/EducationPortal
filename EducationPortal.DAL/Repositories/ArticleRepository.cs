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
    public class ArticleRepository : IRepository<Article>
    {
        private FSContext context;

        public ArticleRepository(FSContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<Article> GetAll()
        {
            return this.context.Storage.GetAll<Article>();
        }

        public Article Get(Guid id)
        {
            return this.context.Storage.Get<Article>(id);
        }

        public IEnumerable<Article> Find(Func<Article, bool> predicate)
        {
            return this.context.Storage.Find(predicate);
        }

        public Task Create(Article item)
        {
            return this.context.Storage.CreateAsync(item);
        }

        public Task Update(Guid id, Article item)
        {
            return this.context.Storage.UpdateAsync(id, item);
        }

        public void Delete(Guid id)
        {
            this.context.Storage.Delete<Article>(id);
        }
    }
}
