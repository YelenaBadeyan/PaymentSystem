using MediatR;
using PaymentSystem.DTOs.UserDTOs;

namespace PaymentSystem.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<GetUserDto>
    {
        public int Id { get; set; }
    }
}
