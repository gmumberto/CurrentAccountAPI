using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrentAccountAPI.Domain.Entity
{
    [Table("Transaction_TB")]
    public class Transaction
    {
        [Key]
        public int transactionID { get; set; }
        public int customerID { get; set; }
        public DateTime transactionDate { get; set; }
        public decimal transactionAmount { get; set; }
        public int? transactionReceivedFromAccount { get; set; }
        public int? transactionSentToAccount { get; set; }
        public decimal transactionRemainingBalance { get; set; }
    }
}
