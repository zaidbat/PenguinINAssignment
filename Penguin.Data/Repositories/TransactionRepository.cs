using Penguin.Data.Context;
using Penguin.Domain.Entities;
using Penguin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public DBContext _context;
        public TransactionRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<BudgetTransaction> GetByIdAsync(int? Id)
        {
            return await _context.BudgetTransactionsTbls.FindAsync(Id);
        }
        public async Task InsertAsync(BudgetTransaction budgetTransaction)
        {
            await _context.BudgetTransactionsTbls.AddAsync(budgetTransaction);
            await _context.SaveChangesAsync();
        }

        public IQueryable<BudgetTransaction> GetAll()
        {
            return _context.BudgetTransactionsTbls.AsQueryable();
        }

        public async Task UpdateAsync(BudgetTransaction transaction)
        {
            _context.BudgetTransactionsTbls.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BudgetTransaction transaction)
        {
            _context.BudgetTransactionsTbls.Remove(transaction);
            await _context.SaveChangesAsync();

        }


    }
}
