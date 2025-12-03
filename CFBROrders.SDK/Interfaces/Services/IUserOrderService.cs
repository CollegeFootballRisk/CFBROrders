using CFBROrders.SDK.Data_Models;
using CFBROrders.SDK.Models;

namespace CFBROrders.SDK.Interfaces.Services
{
    public interface IUserOrderService
    {
        public UserOrder GetSingleUserOrder(string username, int seasonId, int turnId);

        public List<UserOrder> GetAllUserOrdersByTurn(int seasonId, int turnId);

        public IOperationResult InsertUserOrder(UserOrder userOrder);

        public IOperationResult UpdateUserOrder(UserOrder userOrder);
    }
}
