using AccountingNotebook.BLL.Providers.Contracts;
using AccountingNotebook.DAL.Data.Repositories.Contracts;
using AccountingNotebook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.BLL.Providers.Implementations
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.FindFirstAsync(b => b.Id == id);
            return user;
        }
        public async Task<User> EditUserAsync(User user)
        {
            var editUser = await _userRepository.UpdateAsync(user);
            return editUser;
        }
    }
}
