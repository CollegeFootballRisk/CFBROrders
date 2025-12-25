/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
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