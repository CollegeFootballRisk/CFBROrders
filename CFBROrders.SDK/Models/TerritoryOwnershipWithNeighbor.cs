using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CFBROrders.SDK.Models
{
    public partial class TerritoryOwnershipWithNeighbors
    {
        public List<Neighbor> NeighborList
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Neighbors))
                    return new List<Neighbor>();

                try
                {
                    return JsonSerializer.Deserialize<List<Neighbor>>(Neighbors) ?? new List<Neighbor>();
                }
                catch
                {
                    return new List<Neighbor>();
                }
            }
        }

        public int Priority { get; set; } = 1;
    }

    public class Neighbor
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string shortName { get; set; } = "";
        public string owner { get; set; } = "";
    }
}
