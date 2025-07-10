using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data;
using PaymentSystem.DTOs.UserDTOs;
using PaymentSystem.Queries.UserQueries;

namespace PaymentSystem.Handlers.UserHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserDto>
    {
        private readonly ApplicationDBContext _db;

        public GetUserByIdHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<GetUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _db.Users
                .Where(u => u.ID == request.Id)
                .Select(u => new GetUserDto
                {
                    ID = u.ID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .FirstOrDefaultAsync();
            return user;
        }
    }
}
