namespace CurrentAccountAPI.Domain.DTOs
{
    public class CustomerDTO
    {
        public int customerID { get; set; }
        public string customerName { get; set; }
        public string customerSurename { get; set; }
        public decimal customerAmountInAccount { get; set; }
        public decimal customerCredit { get; set; }
        public int customerAccount { get; set; }
        public List<TransactionDTO> Transactions { get; set; } = new List<TransactionDTO>();
    }
}
