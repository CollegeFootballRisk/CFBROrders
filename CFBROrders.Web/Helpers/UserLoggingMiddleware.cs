using System.Security.Claims;

namespace CFBROrders.Web.Helpers
{
    public class UserLoggingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

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