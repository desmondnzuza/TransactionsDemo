using System.ComponentModel.DataAnnotations;

namespace IS.Transactions.Demo.Core.Model
{
    public class Transaction
    {
        [Key]
        public int Code { get; set; }
        public Account TransactingAccount { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public System.DateTime CaptureDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
