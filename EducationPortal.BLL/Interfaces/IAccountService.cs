using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.DAL.Entities;

namespace EducationPortal.BLL.Interfaces
{
    public interface IAccountService : IDisposable
    {
        Task<OperationDetails> Create(AccountDTO accountDto);

        Account Authenticate(AccountDTO userDto);
    }
}
