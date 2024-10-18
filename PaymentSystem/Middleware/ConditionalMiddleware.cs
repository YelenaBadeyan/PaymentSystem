namespace PaymentSystem.Middleware
{
    public class ConditionalMiddleware
    {
        private readonly RequestDelegate _next;

        public ConditionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Post)
            {
                Console.WriteLine($"Conditional Middleware executing for POST request: {context.Request.Path}");
            }

            await _next(context);
        }
    }
}
