using AccountingNotebook.BLL.Providers.Contracts;
using AccountingNotebook.DAL.Data.Repositories.Contracts;
using AccountingNotebook.DAL.Models;
using AccountingNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.BLL.Providers.Implementations
{
    public class TransactionProvider : ITransactionProvider
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionProvider(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<ICollection<Transaction>> GetAllTransactionsAsync()
        {
            var transaction = await _transactionRepository.GetItemsAsync();
            return transaction;
        }

        public async Task<Transaction> GetTransactionByIdAsync(string id)
        {
            var transaction = await _transactionRepository.FindFirstAsync(b => b.Id == id);
            return transaction;
        }


        public async Task<Transaction> CreateTransactionAsync(TransactionViewModel model)
        {
            var transaction = ModelConverter.ConvertViewToData(model);
            var addedTransaction = await _transactionRepository.AddAsync(transaction);
            return addedTransaction;
        }

    }
}

