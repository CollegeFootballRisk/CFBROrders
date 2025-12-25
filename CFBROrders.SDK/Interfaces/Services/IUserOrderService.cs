/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
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
