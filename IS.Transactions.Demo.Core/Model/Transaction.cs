namespace IS.Transactions.Demo.Core.Model
{
    public class Transaction
    {
        public int Code { get; set; }
        public Account TransactingAccount { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public System.DateTime CaptureDate { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
