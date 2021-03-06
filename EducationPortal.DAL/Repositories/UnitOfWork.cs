using System.Threading.Tasks;
using EducationPortal.DAL.EF;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.DAL.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly EducationPortalContext context;

        public IRepository<T> Repository { get; }

        public UnitOfWork(EducationPortalContext context)
        {
            this.context = context;
            this.Repository = new Repository<T>(context);
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
