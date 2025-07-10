using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data;
using PaymentSystem.DTOs.PaymetDTOs;
using PaymentSystem.Queries.PaymentQuesries;

namespace PaymentSystem.Handlers.PaymentHandlers
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, GetPaymentDto>
    {
        private readonly ApplicationDBContext _db;

        public GetPaymentByIdHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<GetPaymentDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var payment = await _db.Payments.Where(p => p.ID == request.Id).Select(p => new GetPaymentDto()
            {
                ID = p.ID,
                UserID = p.UserID,
                Amount = p.Amount,
                PaymentDate = p.PaymentDate,
                PaymentMethodName = p.PaymentDetail.Method.Name
            }).FirstOrDefaultAsync();

            return payment;
        }
    }
}
