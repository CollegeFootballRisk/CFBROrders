using CFBROrders.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBROrders.SDK.Interfaces.Services
{
    public interface ITerritoryService
    {
        public List<TerritoryOwnershipWithNeighbor> GetDefendableTerritories(int season, int day, string team);

        public List<TerritoryOwnershipWithNeighbor> GetAttackableTerritories(int season, int day, string team);

        public string GetTerritoryNameByTerritoryId(int? id);
    }
}
