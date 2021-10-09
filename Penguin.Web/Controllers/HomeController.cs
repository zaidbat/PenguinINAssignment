using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Penguin.Domain.Entities;
using Penguin.Domain.Interfaces;
using Penguin.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Penguin.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionRepository _transaction;
        public HomeController(ITransactionRepository transaction)
        {
            _transaction = transaction;
        }

        public IActionResult Index()
        {
            var transactions = _transaction.GetAll().Select(n => new TransactionVM()
            {
                Id = n.Id,
                CreateDate = n.CreateDate,
                Description = n.Description,
                TransactionAmount = n.TransactionAmount
            });

            return View(transactions);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            if(Id == 0)
                return View();

            var transaction = await _transaction.GetByIdAsync(Id);
            var transactionVM = new TransactionVM()
            {
                Description = transaction.Description,
                TransactionAmount = transaction.TransactionAmount,
                CreateDate = transaction.CreateDate,
                Id = transaction.Id

            };
            return View(transactionVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TransactionVM transactionVM)
        {
            if(transactionVM.Id == 0)
            { 
                var transaction = new BudgetTransaction()
                {
                    Description = transactionVM.Description,
                    CreateDate = DateTime.Now,
                    TransactionAmount = transactionVM.TransactionAmount

                };
                await _transaction.InsertAsync(transaction);
            }
            else
            {
                var transaction = await _transaction.GetByIdAsync(transactionVM.Id);
                transaction.Description = transactionVM.Description;
                transaction.TransactionAmount = transactionVM.TransactionAmount;
                await _transaction.UpdateAsync(transaction);
            }
            

            return RedirectToAction("Index");

        }


        public async Task<ActionResult> Delete(int Id)
        {
            if(Id == 0)
                return RedirectToAction("Index");

            var transaction = await _transaction.GetByIdAsync(Id);
            await _transaction.DeleteAsync(transaction);
            return RedirectToAction("Index");

        }

    }
}
