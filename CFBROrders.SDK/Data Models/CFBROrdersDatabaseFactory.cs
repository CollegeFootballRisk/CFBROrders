/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using Npgsql;
using NPoco;

namespace CFBROrders.SDK.DataModel
{
    public class CFBROrdersDatabaseFactory
    {
        public static DatabaseFactory DbFactory { get; set; }

        public static string ConnectionString
        {
            get
            {
                return DbFactory.GetDatabase().ConnectionString;
            }
        }

        public static void Setup(string connectionString)
        {
            DbFactory = DatabaseFactory.Config(x =>
            {
                x.UsingDatabase(() =>
                    new Database(connectionString, DatabaseType.PostgreSQL, NpgsqlFactory.Instance)
                );
            });
        }
    }
}