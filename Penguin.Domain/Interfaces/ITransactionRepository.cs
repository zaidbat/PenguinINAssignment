using Penguin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        public Task<BudgetTransaction> GetByIdAsync(int? Id);

        public Task InsertAsync(BudgetTransaction budgetTransaction);

        public IQueryable<BudgetTransaction> GetAll();

        public Task UpdateAsync(BudgetTransaction transaction);

        public Task DeleteAsync(BudgetTransaction transaction);
    }
}
