using MediatR;
using PaymentSystem.DTOs.UserDTOs;

namespace PaymentSystem.Queries.UserQueries
{
    public class CreateUserQuery : IRequest<CreateUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

}
