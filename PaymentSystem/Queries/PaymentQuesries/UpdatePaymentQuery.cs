using MediatR;

namespace PaymentSystem.Queries.PaymentQuesries
{
    public class UpdatePaymentQuery : IRequest<int>
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
