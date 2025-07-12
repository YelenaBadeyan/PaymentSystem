using MediatR;
using PaymentSystem.Data;
using PaymentSystem.Queries.PaymentQuesries;

namespace PaymentSystem.Handlers.PaymentHandlers
{
    public class UpdatePaymentHandler : IRequestHandler< UpdatePaymentCommand, int>
    {
        private readonly ApplicationDBContext _db;

        public UpdatePaymentHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _db.Payments.FindAsync(request.Id);

            payment.Amount = request.Amount;
            payment.PaymentDate = request.PaymentDate;

            await _db.SaveChangesAsync();
            return payment.ID;
        }
    }
}
