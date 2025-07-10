using MediatR;
using PaymentSystem.DTOs.PaymetDTOs;

namespace PaymentSystem.Queries.PaymentQuesries
{
    public class GetAllPaymentsQuery : IRequest<List<GetPaymentDto>>
    {
    }
}
