using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;

namespace EducationPortal.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Video> Videos { get; }

        IRepository<Article> Articles { get; }

        IRepository<Book> Books { get; }

        void Save();
    }
}
