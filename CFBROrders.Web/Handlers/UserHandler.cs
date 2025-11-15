using CFBROrders.SDK.Interfaces.Services;
using CFBROrders.SDK.Models;
using CFBROrders.Web.Interfaces.Handlers;
using System.Security.Claims;

namespace CFBROrders.Web.Handlers
{
    public class UserHandler(IHttpContextAccessor httpContextAccessor, IUserService userService) : IUserHandler
    {
        private User? _currentUser;

        public User? CurrentUser
        {
            get
            {
                if (_currentUser != null)
                    return _currentUser;

                var userClaims = httpContextAccessor.HttpContext?.User;
                if (userClaims?.Identity?.IsAuthenticated ?? false)
                {
                    var userIdClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (!string.IsNullOrEmpty(userIdClaim) && int.TryParse(userIdClaim, out var userId))
                    {
                        _currentUser = userService.GetUserById(userId);
                    }
                }

                return _currentUser;
            }
            private set => _currentUser = value;
        }

        public string? Username => CurrentUser?.Uname;

        public void SetUser(User user)
        {
            CurrentUser = user;
        }
    }
}
