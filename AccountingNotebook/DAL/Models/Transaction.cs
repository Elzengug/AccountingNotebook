using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.DAL.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
