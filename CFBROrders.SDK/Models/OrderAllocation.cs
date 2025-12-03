using NPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CFBROrders.SDK.Models
{
    public partial class OrderAllocation
    {
        [ResultColumn]
        public string TerritoryName { get; set; }
    }
}
