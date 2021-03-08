using System.Threading.Tasks;
using EducationPortal.DAL.EF;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationPortalContext context;

        public UnitOfWork(EducationPortalContext context)
        {
            this.context = context;
        }

        public IRepository<T> Repository<T>() where T : class, IEntity
        {
            return new Repository<T>(this.context);
        }

        public async Task Commit()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
