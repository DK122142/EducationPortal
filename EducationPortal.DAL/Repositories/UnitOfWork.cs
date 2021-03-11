using System.Threading.Tasks;
using EducationPortal.DAL.DbContexts;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationPortalContext context;

        public UnitOfWork(EducationPortalContext context) => this.context = context;

        public IRepository<T> Repository<T>() where T : class, IEntity => new Repository<T>(this.context);

        public async Task<int> Commit() => await this.context.SaveChangesAsync();

        public void Dispose() => this.context.Dispose();
    }
}
