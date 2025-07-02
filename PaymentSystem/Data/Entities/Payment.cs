using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Data.Entities
{

    public class Payment
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public User User { get; set; }

        public PaymentDetail PaymentDetail { get; set; }
    }
}
