/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
namespace CFBROrders.Web.Models
{
    public class CurrentUser
    {
        public string Color { get; set; }
        public string ContrastColor { get; set; }
        public int Overall { get; set; }
        public int Season { get; set; }
        public string Team { get; set; }
        public int TeamId { get; set; }
        public int Turn { get; set; }
        public string Username { get; set; }
    }

}
