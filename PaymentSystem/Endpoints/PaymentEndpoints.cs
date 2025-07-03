using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data;
using PaymentSystem.Data.Entities;
using PaymentSystem.DTOs.PaymetDTOs;

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

        private static async Task<IResult> GetAllPayments(ApplicationDBContext db)
        {
            var payments = await db.Payments.Select(p => new GetPaymentDto()
            {
                ID = p.ID,
                UserID = p.UserID,
                Amount = p.Amount,
                PaymentDate = p.PaymentDate,
                PaymentMethodName = p.PaymentDetail.Method.Name
            }).ToListAsync();

            return Results.Ok(payments);

        }

        private static async Task<IResult> GetPaymentById(ApplicationDBContext db, [FromRoute]int id)
        {
            var payment = await db.Payments.Where(p => p.ID == id).Select(p => new GetPaymentDto()
            {
                ID = p.ID,
                UserID = p.UserID,
                Amount = p.Amount,
                PaymentDate = p.PaymentDate,
                PaymentMethodName = p.PaymentDetail.Method.Name
            }).FirstOrDefaultAsync();

            if (payment == null)
            {
                return Results.NotFound();

            }
            return Results.Ok(payment);
        }

        private static async Task<IResult> UpdatePayment(ApplicationDBContext db, [FromRoute]int id, [FromBody]UpdatePaymentDto input)
        {
            var payment = await db.Payments.FindAsync(id);

            if(payment == null)
                return Results.NotFound();

            payment.Amount = input.Amount;
            payment.PaymentDate = input.PaymentDate;

            await db.SaveChangesAsync();

            return Results.Ok(payment);


        }

        private static async Task<IResult> CreatePayment(ApplicationDBContext db, CreatePaymentDto input)
        {
            var payment = new Payment()
            {
                Amount = input.Amount,
                UserID = input.UserID,
                PaymentDate = input.PaymentDate

            };

            await db.Payments.AddAsync(payment);
            await db.SaveChangesAsync();

            return Results.Ok(payment);
        }
    }
}
