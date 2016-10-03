namespace IS.Transactions.Demo.Core.Model
{
    public class Account
    {
        public int Code { get; set; }
        public Person AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public double OutstandingBalance { get; set; }
    }
}
