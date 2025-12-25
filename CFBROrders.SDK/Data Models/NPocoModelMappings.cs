/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using CFBROrders.SDK.Models;
using NPoco.FluentMappings;

namespace CFBROrders.SDK.Data_Models
{
    public class NPocoModelMappings : Mappings
    {
        public NPocoModelMappings()
        {
            For<TerritoryOwnershipWithNeighbor>()
                .Columns(x =>
                {
                    x.Column(y => y.NeighborList).Result();
                    x.Column(y => y.Tier).Result();
                    x.Column(y => y.StarPowerAllocation).Result();
                });

            For<OrderAllocation>()
                .TableName("order_allocations")
                .PrimaryKey("id")
                .Columns(x =>
                {
                    x.Column(y => y.TerritoryName).Result();
                });
        }
    }
}