/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
namespace CFBROrders.Web.Models
{
    public enum SettingType
    {
        Boolean,
        Select
    }

    public class SettingOption
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public SettingType Type { get; set; }
        public bool BoolValue { get; set; }
        public string? SelectedValue { get; set; }
        public List<string>? Options { get; set; }

        public SettingOption(string name, string label)
        {
            Name = name;
            Label = label;
            Type = SettingType.Boolean;
            BoolValue = false;
        }

        public SettingOption(string name, string label, List<string> options, string defaultValue)
        {
            Name = name;
            Label = label;
            Type = SettingType.Select;
            Options = options;
            SelectedValue = defaultValue;
        }
    }
}
