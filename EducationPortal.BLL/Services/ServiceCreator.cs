using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.FileStorage.Core.Internal;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.Identity;

namespace EducationPortal.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IAccountService CreateAccountService(string connection = null)
        {
            return new AccountService(new AccountManager(new IdentityContext(new FileStorageSetInitializer())));
        }
    }
}
