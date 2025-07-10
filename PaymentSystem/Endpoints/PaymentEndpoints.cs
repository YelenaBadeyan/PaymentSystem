using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data;
using PaymentSystem.Data.Entities;
using PaymentSystem.DTOs.PaymetDTOs;
using PaymentSystem.Queries.PaymentQuesries;

namespace PaymentSystem.Endpoints
{
    public static class PaymentEndpoints
    {
        public static void MapPaymentEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/payment", GetAllPayments);
            app.MapGet("api/payment/{id}", GetPaymentById);
            app.MapPut("api/payment/{id}", UpdatePayment);
            app.MapPost("api/payment", CreatePayment);
        }

        private static async Task<IResult> GetAllPayments(IMediator mediator)
        {
            var result = await mediator.Send(new GetAllPaymentsQuery());

            return Results.Ok(result);

        }

        private static async Task<IResult> GetPaymentById(IMediator mediator, [FromRoute]int id)
        {
            var payment = await mediator.Send(new GetPaymentByIdQuery(){ Id=id });

            if (payment == null)
            {
                return Results.NotFound();

            }
            return Results.Ok(payment);
        }

        private static async Task<IResult> UpdatePayment(IMediator mediator, [FromRoute]int id, [FromBody]UpdatePaymentDto input)
        {
            var result = await mediator.Send(new UpdatePaymentQuery()
            {
                Id = id,
                Amount = input.Amount,
                PaymentDate = input.PaymentDate
            });

            return Results.Ok(result);

        }

        private static async Task<IResult> CreatePayment(IMediator mediator, CreatePaymentDto input)
        {
            var result = await mediator.Send(new CreatePaymentQuery()
            {
                UserID = input.UserID,
                Amount = input.Amount,
                PaymentDate = input.PaymentDate
            });

            return Results.Ok(result);
        }
    }
}
