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
    public class BookRepository : IRepository<Book>
    {
        private FSContext context;

        public BookRepository(FSContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<Book> GetAll()
        {
            return this.context.Storage.GetAll<Book>();
        }

        public Book Get(Guid id)
        {
            return this.context.Storage.Get<Book>(id);
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return this.context.Storage.Find(predicate);
        }

        public Task Create(Book item)
        {
            return this.context.Storage.CreateAsync(item);
        }

        public Task Update(Guid id, Book item)
        {
            return this.context.Storage.UpdateAsync(id, item);
        }

        public void Delete(Guid id)
        {
            this.context.Storage.Delete<Book>(id);
        }
    }
}
