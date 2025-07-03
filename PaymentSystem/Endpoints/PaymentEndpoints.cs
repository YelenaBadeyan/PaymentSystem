using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data;
using PaymentSystem.DTOs.PaymetDTOs;

namespace PaymentSystem.Endpoints
{
    public static class PaymentEndpoints
    {
        public static void MapPaymentEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/payment", GetAllPayments);
            app.MapGet("api/payment/{id}", GetPaymentById);
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
    }
}
