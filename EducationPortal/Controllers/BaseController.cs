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
        public StorageController storageController { get; }

        protected BaseController()
        {
            storageController = new StorageController();
        }
    }
}
