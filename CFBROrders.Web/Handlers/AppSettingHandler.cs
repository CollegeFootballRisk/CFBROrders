/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using System.ComponentModel;
using System.Text.Json;
using Microsoft.JSInterop;
using CFBROrders.Web.Models;
using CFBROrders.Web.Interfaces.Handlers;

namespace CFBROrders.Web.Handlers
{
    public class AppSettingHandler(IJSRuntime JS) : IAppSettingHandler
    {
        private const string StorageKey = "CFBROrders.settings";

        public AppSetting Settings { get; private set; } = new();

        public bool LightMode => Settings.LightMode;
        public string Branding => Settings.Branding;
        public string SeasonalBackground => Settings.SeasonalBackground;

        public async Task InitializeAsync()
        {
            var json = await JS.InvokeAsync<string>("appSettings.get", StorageKey);

            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    Settings = JsonSerializer.Deserialize<AppSetting>(json) ?? new();
                }
                catch
                {
                    Settings = new();
                }
            }

            Normalize();
            await ApplyAsync();
        }

        public Task SetLightModeAsync(bool value) =>
            UpdateAsync(s => s.LightMode = value);

        public Task SetBrandingAsync(string value) =>
            UpdateAsync(s => s.Branding = value);

        public Task SetSeasonalBackgroundAsync(string value) =>
            UpdateAsync(s => s.SeasonalBackground = value);

        private async Task UpdateAsync(Action<AppSetting> update)
        {
            update(Settings);
            Normalize();

            var json = JsonSerializer.Serialize(Settings);
            await JS.InvokeVoidAsync("appSettings.set", StorageKey, json);

            await ApplyAsync();
        }

        private async Task ApplyAsync()
        {
            await JS.InvokeVoidAsync(
                "setTheme",
                Settings.LightMode ? "light" : "dark"
            );

            await JS.InvokeVoidAsync("setBranding", Settings.Branding);

            await JS.InvokeVoidAsync(
                "setSeasonalEffects",
                Settings.SeasonalBackground
            );
        }

        private void Normalize()
        {
            Settings.Branding ??= "Normal - Rainbow";
            Settings.SeasonalBackground ??= "None";
        }
    }

}
