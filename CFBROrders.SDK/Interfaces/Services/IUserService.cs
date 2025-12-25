/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using CFBROrders.SDK.Models;

namespace CFBROrders.SDK.Interfaces.Services
{
    public interface IUserService
    {
        public List<User> GetAllUsers();

        public User GetUserByPlatformAndUsername(string platform, string uname);

        public int GetOverallByUserId(int userId);

        public User GetUserById(int userId);
    }
}
