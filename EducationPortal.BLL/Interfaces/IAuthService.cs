using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface IAuthService
    {
        public Task<OperationDetails<AccountDto>> Register(string username, string password);

        public Task<OperationDetails<AccountDto>> Login(string username, string password);

        public Task LogOut();
    }
}
