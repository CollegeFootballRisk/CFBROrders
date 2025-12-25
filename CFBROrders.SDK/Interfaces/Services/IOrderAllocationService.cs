/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using CFBROrders.SDK.Data_Models;
using CFBROrders.SDK.Models;

namespace CFBROrders.SDK.Interfaces.Services
{
    public interface IOrderAllocationService
    {
        public List<OrderAllocation> GetAllOrderAllocations(int teamId, int seasonId, int turnId);

        public List<TierSummary> GetTierSummaries(IEnumerable<OrderAllocation> orderAllocations, IEnumerable<UserOrder> userOrders);

        public IOperationResult InsertOrderAllocation(OrderAllocation orderAllocation);

        public void InsertOrderAllocationWithoutTransaction(OrderAllocation orderAllocation);

        public IOperationResult InsertOrderAllocations(List<OrderAllocation> orderAllocations);

        public void RecalculateAllocationForTerritory(int seasonId, int turnId, int territoryId);
    }
}