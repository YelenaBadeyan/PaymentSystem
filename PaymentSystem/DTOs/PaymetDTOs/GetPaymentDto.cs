namespace PaymentSystem.DTOs.PaymetDTOs
{
    public class GetPaymentDto
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public string PaymentMethodName { get; set; }
    }
}
