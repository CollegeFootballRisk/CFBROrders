/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using System.Text.Json;

namespace CFBROrders.SDK.Models
{
    public partial class TerritoryOwnershipWithNeighbor
    {
        private static readonly JsonSerializerOptions _jsonOptions =
            new()
            { PropertyNameCaseInsensitive = true };

        public List<Neighbor> NeighborList { get; set; } = [];

        public int Tier { get; set; } = 1;

        public int StarPowerAllocation { get; set; }
    }
}
