using MediatR;
using PaymentSystem.Data;
using PaymentSystem.Data.Entities;
using PaymentSystem.DTOs.UserDTOs;
using PaymentSystem.Queries.UserQueries;

namespace PaymentSystem.Handlers.UserHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly ApplicationDBContext _db;

        public CreateUserHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var result = new CreateUserResponse()
            {
                LocationUrl = $"/api/users/{user.ID}",
                UserId = user.ID
            };
            return result;
        }
    }
}
