using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<OperationDetails> Create(AccountDTO accountDto);

        Account Authenticate(AccountDTO userDto);
    }
}
