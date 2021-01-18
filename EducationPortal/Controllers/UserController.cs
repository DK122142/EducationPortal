using EducationPortal.Entities;
using EducationPortal.Storage;

namespace EducationPortal.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ITableManager tableManager) : base(tableManager)
        {
            TableManager.StorageController.CreateTable<User>();
        }
    }
}
