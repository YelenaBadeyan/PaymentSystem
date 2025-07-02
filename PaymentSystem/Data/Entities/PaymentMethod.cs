using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Data.Entities
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
