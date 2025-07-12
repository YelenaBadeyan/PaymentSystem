using MediatR;

namespace PaymentSystem.Queries.PaymentQuesries
{
    public class CreatePaymentCommand : IRequest<int>
    {
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
