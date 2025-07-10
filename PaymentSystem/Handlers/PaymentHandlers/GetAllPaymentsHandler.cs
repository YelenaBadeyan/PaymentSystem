using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data;
using PaymentSystem.DTOs.PaymetDTOs;
using PaymentSystem.Queries.PaymentQuesries;

namespace PaymentSystem.Handlers.PaymentHandlers
{
    public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsQuery, List<GetPaymentDto>>
    {
        private readonly ApplicationDBContext _db;

        public GetAllPaymentsHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<List<GetPaymentDto>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = await _db.Payments.Select(p => new GetPaymentDto()
            {
                ID = p.ID,
                UserID = p.UserID,
                Amount = p.Amount,
                PaymentDate = p.PaymentDate,
                PaymentMethodName = p.PaymentDetail.Method.Name
            }).ToListAsync();
            return payments;
        }
    }
}
