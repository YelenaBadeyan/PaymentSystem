using MediatR;

namespace PaymentSystem.Queries.PaymentQuesries
{
    public class CreatePaymentQuery : IRequest<int>
    {
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
