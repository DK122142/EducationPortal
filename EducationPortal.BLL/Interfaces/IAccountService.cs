using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;

namespace EducationPortal.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<OperationDetails> RegisterAccount(AccountDTO accountDto);

        AccountDTO Authenticate(AccountDTO userDto);
    }
}
