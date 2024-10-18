namespace PaymentSystem.Middleware
{
    public class ResponseHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            context.Response.Headers.Add("X-Custom-Header", $"Middleware-Test-{DateTime.Now}");
        }
    }


}
