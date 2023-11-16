using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrentAccountAPI.Domain.Entity
{
    [Table("Customer_TB")]
    public class Customer
    {
        [Key]
        public int customerID { get; set; }
        public string customerName { get; set; }
        public string customerSurename { get; set; }
        public decimal customerAmountInAccount { get; set; }
        public decimal customerCredit { get; set; }
        public int customerAccount { get; set; }
    }
}
