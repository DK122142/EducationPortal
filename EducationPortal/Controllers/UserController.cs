using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Entities;

namespace EducationPortal.Controllers
{
    public class UserController : BaseController
    {
        public UserController()
        {
            StorageController.CreateTable<User>();
        }
    }
}
