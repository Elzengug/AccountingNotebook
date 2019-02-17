using AccountingNotebook.DAL.Models;
using AccountingNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.BLL.Providers
{
    public static class ModelConverter
    {
        public static Transaction ConvertViewToData(TransactionViewModel model)
        {
            return new Transaction
            {
                EffectiveDate = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString(),
                Type = model.Type,
                Amount = model.Amount

            };
        }
        public static TransactionViewModel ConvertDataToView(Transaction transaction)
        {
            return new TransactionViewModel
            {
                Amount = transaction.Amount,
                Type = transaction.Type
            };
        }
    }
}
