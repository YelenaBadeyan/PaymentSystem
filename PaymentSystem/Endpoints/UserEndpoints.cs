using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PaymentSystem.Data;
using PaymentSystem.Data.Entities;
using PaymentSystem.DTOs.UserDTOs;
using PaymentSystem.Queries.UserQueries;

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

        private static async Task<IResult> GetAllUsers(IMediator mediator)
        {
            var users = await mediator.Send(new GetAllUsersQuery());

            return Results.Ok(users);
        }

        private static async Task<IResult> GetUserById(IMediator mediator, int id)
        {
            var user = await mediator.Send(new GetUserByIdQuery{ Id = id });

            return Results.Ok(user);
        }

        private static async Task<IResult> CreateUser(IMediator mediator, CreateUserDto input)
        {
            var result = await mediator.Send(new CreateUserCommand()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email
            });

            return Results.Created(result.LocationUrl, result.UserId);
        }

        private static async Task<IResult> UpdateUser(IMediator mediator, int id, UpdateUserDto input)
        {
            var result = await mediator.Send(new UpdateUserCommand()
            {
                ID = id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email
            });

            return Results.Ok(result);
        }
    }

}
