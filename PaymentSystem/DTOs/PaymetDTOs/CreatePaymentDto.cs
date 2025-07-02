namespace PaymentSystem.DTOs.PaymetDTOs
{
    public class CreatePaymentDto
    {
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
