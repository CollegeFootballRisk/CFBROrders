/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
namespace CFBROrders.Web.Models
{
    public class AppSetting
    {
        public bool LightMode { get; set; } = false;
        public string Branding { get; set; } = "Normal - Rainbow";
        public string SeasonalBackground { get; set; } = "Winter";
    }
}
