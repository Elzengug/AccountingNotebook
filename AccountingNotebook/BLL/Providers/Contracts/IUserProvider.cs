using AccountingNotebook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.BLL.Providers.Contracts
{
    public interface IUserProvider
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> EditUserAsync(User user);
    }
}
