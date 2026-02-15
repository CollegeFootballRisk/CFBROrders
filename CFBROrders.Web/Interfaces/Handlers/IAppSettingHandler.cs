/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using CFBROrders.Web.Models;

namespace CFBROrders.Web.Interfaces.Handlers
{
    public interface IAppSettingHandler
    {
        AppSetting Settings { get; }
        bool LightMode { get; }
        string Branding { get; }
        string SeasonalBackground { get; }
        Task InitializeAsync();
        Task SetLightModeAsync(bool value);
        Task SetBrandingAsync(string value);
        Task SetSeasonalBackgroundAsync(string value);
    }
}



