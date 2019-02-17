using AccountingNotebook.DAL.Models;
using AccountingNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.BLL.Providers.Contracts
{
    public interface ITransactionProvider
    {
        Task<ICollection<Transaction>> GetAllTransactionsAsync();
        Task<Transaction> GetTransactionByIdAsync(string id);
        Task<Transaction> CreateTransactionAsync(TransactionViewModel model);
    }
}
