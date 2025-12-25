/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
namespace CFBROrders.SDK.Interfaces.Services
{
    public interface ITeamService
    {
        public string GetTeamNameByTeamId(int id);

        public int GetTeamIdByTeamName(string name);

        public string GetTeamColorByTeamId(int id);

        public int GetTeamStarPowerForTurn(string tname, int season, int day);
    }
}
