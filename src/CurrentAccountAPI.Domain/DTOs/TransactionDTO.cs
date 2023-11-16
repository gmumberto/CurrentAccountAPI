namespace CurrentAccountAPI.Domain.DTOs
{
    public class TransactionDTO
    {
        public int transactionID { get; set; }
        public int customerID { get; set; }
        public DateTime transactionDate { get; set; }
        public decimal transactionAmount { get; set; }
        public int? transactionReceivedFromAccount { get; set; }
        public int? transactionSentToAccount { get; set; }
        public decimal transactionRemainingBalance { get; set; }
    }
}
