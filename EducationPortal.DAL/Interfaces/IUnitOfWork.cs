using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Identity;

namespace EducationPortal.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Video> Videos { get; }

        IRepository<Article> Articles { get; }

        IRepository<Book> Books { get; }

        IRepository<Course> Courses { get; }
    }
}
