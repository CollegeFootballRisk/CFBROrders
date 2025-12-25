/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
namespace CFBROrders.SDK.Models
{
    public partial class TierSummary
    {
        public int Tier { get; set; }
        public int Players { get; set; }
        public int Quota { get; set; }
        public int AssignedStars { get; set; }
        public double QuotaPercent { get; set; }
        public int TotalTerritories { get; set; }
        public int CompletedTerritories { get; set; }
        public double CompletedPercent { get; set; }
    }
}
