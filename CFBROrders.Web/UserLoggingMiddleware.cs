using System.Security.Claims;

namespace CFBROrders.Web
{
    public class UserLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public UserLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var username = context.User.FindFirstValue("Username");

                using (NLog.ScopeContext.PushProperty("Username", username))
                {
                    await _next(context);
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}