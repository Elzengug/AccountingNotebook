using AccountingNotebook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AccountingNotebook.DAL.Data.Repositories.Contracts
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }
}
