using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Data.Entities
{
    public class PaymentDetail
    {
        [Key]
        public int ID { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
        public int MethodID { get; set; }
        public PaymentMethod Method { get; set; }
        public string Description { get; set; }
    }
}
