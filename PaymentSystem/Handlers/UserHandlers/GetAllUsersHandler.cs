using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data;
using PaymentSystem.DTOs.UserDTOs;
using PaymentSystem.Queries.UserQueries;

namespace PaymentSystem.Handlers.UserHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<GetUserDto>>
    {
        private readonly ApplicationDBContext _db;

        public GetAllUsersHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<List<GetUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _db.Users
                .Select(u => new GetUserDto
                {
                    ID = u.ID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .ToListAsync();
            return users;
        }
    }
}
