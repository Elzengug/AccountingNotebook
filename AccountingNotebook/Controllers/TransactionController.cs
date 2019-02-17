using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingNotebook.BLL.Providers.Contracts;
using AccountingNotebook.DAL.Models;
using AccountingNotebook.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingNotebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IUserProvider _userProvider;
        private readonly ITransactionProvider _transactionProvider;
        public TransactionController(IUserProvider userProvider, ITransactionProvider transactionProvider)
        {
            _userProvider = userProvider;
            _transactionProvider = transactionProvider;
        }

        [HttpGet]
        [Route("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactionsr()
        {
            var transactions = await _transactionProvider.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        [HttpPost]
        [Route("AddCredit")]
        public async Task<IActionResult> AddCredit(TransactionViewModel transaction)
        {
            User user = await _userProvider.GetUserByIdAsync(1);

            if (user.Amount >= transaction.Amount)
            {
                user.Amount -= transaction.Amount;
                await _userProvider.EditUserAsync(user);
                await _transactionProvider.CreateTransactionAsync(transaction);
                return Ok();
            }
            else return StatusCode(403);
           
        }

        [HttpPost]
        [Route("AddDebit")]
        public async Task<IActionResult> AddDebit(TransactionViewModel transaction)
        {
            User user = await _userProvider.GetUserByIdAsync(1);

                user.Amount += transaction.Amount;
                await _userProvider.EditUserAsync(user);
                await _transactionProvider.CreateTransactionAsync(transaction);

            return Ok();
        }
    }
}