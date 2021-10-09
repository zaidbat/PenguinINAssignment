using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Penguin.Web.Models
{
    public class TransactionVM
    {
        public int Id { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Amount")]
        public int TransactionAmount { get; set; }


        [Display(Name = "Transaction Date")]
        public DateTime CreateDate { get; set; }
    }
}
