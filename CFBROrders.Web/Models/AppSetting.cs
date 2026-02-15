/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using System;

namespace CFBROrders.Web.Models
{
    public enum SettingType
    {
        Boolean,
        Select
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class SettingAttribute(string label, SettingType type = SettingType.Boolean, params string[] options) : Attribute
    {
        public string Label { get; } = label;
        public SettingType Type { get; } = type;
        public string[]? Options { get; } = options;
    }

    public class AppSetting
    {
        [Setting("Light Mode", SettingType.Boolean)]
        public bool LightMode { get; set; } = false;

        [Setting("Which branding to use", SettingType.Select,
                 "Normal - Rainbow", "Goose", "Pizza", "Classic", "Normal - White")]
        public string Branding { get; set; } = "Normal - Rainbow";

        [Setting("Seasonal background effects", SettingType.Select,
                 "None", "Valentines", "Spring", "Summer", "Fall", "Halloween", "Thanksgiving", "Winter")]
        public string SeasonalBackground { get; set; } = "Winter";
    }
}
