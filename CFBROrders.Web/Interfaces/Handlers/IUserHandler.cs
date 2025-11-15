using CFBROrders.SDK.Models;

namespace CFBROrders.Web.Interfaces.Handlers
{
    public interface IUserHandler
    {
        string? Username { get; }

        User? CurrentUser { get; }

        public void SetUser(User user);
    }
}