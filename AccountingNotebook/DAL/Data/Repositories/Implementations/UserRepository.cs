using AccountingNotebook.DAL.Data.Contracts;
using AccountingNotebook.DAL.Data.Repositories.Contracts;
using AccountingNotebook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.DAL.Data.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>,  IUserRepository
    {
        public UserRepository(IDbContext dbContext): base(dbContext)
        {

        }
    }
}
