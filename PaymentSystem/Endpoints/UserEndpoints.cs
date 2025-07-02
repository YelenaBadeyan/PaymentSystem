using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data;
using PaymentSystem.Data.Entities;
using PaymentSystem.DTOs.UserDTOs;

namespace PaymentSystem.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/users", GetAllUsers);
            app.MapGet("/api/users/{id}", GetUserById);
            app.MapPost("/api/users", CreateUser);
            app.MapPut("/api/users/{id}", UpdateUser);
        }

        private static async Task<IResult> GetAllUsers(ApplicationDBContext db)
        {
            var users = await db.Users
                .Select(u => new GetUserDto
                {
                    ID = u.ID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .ToListAsync();

            return Results.Ok(users);
        }

        private static async Task<IResult> GetUserById(ApplicationDBContext db, int id)
        {
            var user = await db.Users
                .Where(u => u.ID == id)
                .Select(u => new GetUserDto
                {
                    ID = u.ID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .FirstOrDefaultAsync();

            if (user == null)
                return Results.NotFound();

            return Results.Ok(user);
        }

        private static async Task<IResult> CreateUser(ApplicationDBContext db, CreateUserDto input)
        {
            var user = new User
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return Results.Created($"/api/users/{user.ID}", user.ID);
        }

        private static async Task<IResult> UpdateUser(ApplicationDBContext db, int id, UpdateUserDto input)
        {
            var user = await db.Users.FindAsync(id);

            if (user is null)
                return Results.NotFound();

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.Email = input.Email;

            await db.SaveChangesAsync();

            return Results.Ok($"User {id} updated.");
        }
    }

}
