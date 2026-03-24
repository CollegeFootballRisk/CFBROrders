using CFBROrders.Web.Interfaces.Handlers;
using CFBROrders.Web.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.Text.Json;

namespace CFBROrders.Web.Handlers
{
    public class AppSettingHandler : IAppSettingHandler
    {
        private const string StorageKey = "CFBROrders.settings";
        private readonly ProtectedLocalStorage _storage;
        private readonly IJSRuntime _js;

        public AppSettingHandler(ProtectedLocalStorage storage, IJSRuntime js)
        {
            _storage = storage;
            _js = js;
        }

        public AppSetting Settings { get; private set; } = new();

        public bool LightMode => Settings.LightMode;
        public string Branding => Settings.Branding;
        public string SeasonalBackground => Settings.SeasonalBackground;

        public async Task InitializeAsync()
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", StorageKey);

            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    Settings = JsonSerializer.Deserialize<AppSetting>(json) ?? new AppSetting();
                }
                catch
                {
                    await _js.InvokeVoidAsync("localStorage.removeItem", StorageKey);
                    Settings = new AppSetting();
                }
            }
            else
            {
                var defaultJson = JsonSerializer.Serialize(Settings);
                await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, defaultJson);
            }

            Normalize();
            await ApplyAsync();
        }


        public Task SetLightModeAsync(bool value) => UpdateAsync(s => s.LightMode = value);
        public Task SetBrandingAsync(string value) => UpdateAsync(s => s.Branding = value);
        public Task SetSeasonalBackgroundAsync(string value) => UpdateAsync(s => s.SeasonalBackground = value);

        private async Task UpdateAsync(Action<AppSetting> update)
        {
            update(Settings);
            Normalize();

            var json = JsonSerializer.Serialize(Settings);
            await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, json);

            await ApplyAsync();
        }


        private async Task ApplyAsync()
        {
            await _js.InvokeVoidAsync("setTheme", Settings.LightMode ? "light" : "dark");
            await _js.InvokeVoidAsync("setBranding", Settings.Branding);
            await _js.InvokeVoidAsync("setSeasonalEffects", Settings.SeasonalBackground);
        }

        private void Normalize()
        {
            Settings.Branding ??= "Normal - Rainbow";
            Settings.SeasonalBackground ??= "None";
        }
    }
}
