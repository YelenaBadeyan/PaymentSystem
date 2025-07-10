using MediatR;
using PaymentSystem.DTOs.PaymetDTOs;

namespace PaymentSystem.Queries.PaymentQuesries
{
    public class GetPaymentByIdQuery : IRequest<GetPaymentDto>
    {
        public int Id { get; set; }
    }
}
