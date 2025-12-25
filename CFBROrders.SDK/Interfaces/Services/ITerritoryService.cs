/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using CFBROrders.SDK.Models;

namespace CFBROrders.SDK.Interfaces.Services
{
    public interface ITerritoryService
    {
        public List<TerritoryOwnershipWithNeighbor> GetDefendableTerritories(int season, int day, string team);

        public List<TerritoryOwnershipWithNeighbor> GetAttackableTerritories(int season, int day, string team);

        public string GetTerritoryNameByTerritoryId(int? id);
    }
}
