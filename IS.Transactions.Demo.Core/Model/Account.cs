using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IS.Transactions.Demo.Core.Model
{
    public class Account
    {
        [Key]
        public int Code { get; set; }
        public Person AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public decimal OutstandingBalance { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
