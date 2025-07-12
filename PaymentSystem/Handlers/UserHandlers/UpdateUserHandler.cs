using MediatR;
using PaymentSystem.Data;
using PaymentSystem.Queries.UserQueries;

namespace PaymentSystem.Handlers.UserHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly ApplicationDBContext _db;

        public UpdateUserHandler(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FindAsync(request.ID);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            await _db.SaveChangesAsync();

            return user.ID;
        }
    }
}
