using MediatR;
using PaymentSystem.DTOs.UserDTOs;

namespace PaymentSystem.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<GetUserDto>>
    {

    }
}
