using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
