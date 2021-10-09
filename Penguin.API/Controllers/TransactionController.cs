using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Penguin.API.DTOs;
using Penguin.Domain.Entities;
using Penguin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penguin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transaction;

        public TransactionController(ITransactionRepository transaction)
        {
            _transaction = transaction;
        }

        [HttpGet]
        public async Task<ActionResult> GetTransaction(int? Id)
        {
            if (Id == null)
                return BadRequest();

            var transaction = await _transaction.GetByIdAsync(Id);

            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult> AddTransaction([FromBody] TransactionDTO budgetTransaction)
        {
            var transaction = new BudgetTransaction()
            {
                CreateDate = DateTime.Now,
                Description = budgetTransaction.Description,
                TransactionAmount = budgetTransaction.TransactionAmount
            };

            await _transaction.InsertAsync(transaction);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTransaction(int? Id)
        {
            if (Id == null)
                return BadRequest();

            var transaction = await _transaction.GetByIdAsync(Id);

            if (transaction == null)
                return NotFound();

            await _transaction.DeleteAsync(transaction);
            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> UpdateTransaction([FromBody] TransactionDTO budgetTransaction)
        {


            var transaction = await _transaction.GetByIdAsync(budgetTransaction.Id);

            if (transaction == null)
                return NotFound();

            transaction.TransactionAmount = budgetTransaction.TransactionAmount;
            transaction.Description = budgetTransaction.Description;

            await _transaction.UpdateAsync(transaction);
            return Ok();

        }



    }
}
