using AccountingNotebook.DAL.Data.Contracts;
using AccountingNotebook.DAL.Data.Repositories.Contracts;
using AccountingNotebook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.DAL.Data.Repositories.Implementations
{
    public class TransactionRepository : GenericRepository<Transaction>,  ITransactionRepository
    {
        public TransactionRepository(IDbContext dbContext): base(dbContext)
        {

        }
    }
}
