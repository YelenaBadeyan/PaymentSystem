using MediatR;
using PaymentSystem.Data;
using PaymentSystem.Data.Entities;
using PaymentSystem.Queries.PaymentQuesries;

namespace PaymentSystem.Handlers.PaymentHandlers
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentQuery, int>
    {
        private readonly ApplicationDBContext _db;

        public CreatePaymentHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(CreatePaymentQuery request, CancellationToken cancellationToken)
        {
            var payment = new Payment()
            {
                Amount = request.Amount,
                UserID = request.UserID,
                PaymentDate = request.PaymentDate

            };

            await _db.Payments.AddAsync(payment);
            await _db.SaveChangesAsync();

            return payment.ID;

        }
    }
}
