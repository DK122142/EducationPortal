using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface IAuthService
    {
        public Task<OperationDetails> RegisterAccount(string username, string password);

        public Task<AccountDto> Authenticate(string username, string password);
    }
}
