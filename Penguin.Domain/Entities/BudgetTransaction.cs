using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Penguin.Domain.Entities
{
    public partial class BudgetTransaction
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int TransactionAmount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
