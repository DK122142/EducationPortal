using EducationPortal.Storage;

namespace EducationPortal.Controllers
{
    public abstract class BaseController
    {
        public ITableManager TableManager { get; }

        protected BaseController(ITableManager tableManager)
        {
            this.TableManager = tableManager;
        }
    }
}
