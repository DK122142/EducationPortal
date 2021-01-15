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
        public StorageController StorageController { get; }

        protected BaseController()
        {
            StorageController = new StorageController();
        }
    }
}
