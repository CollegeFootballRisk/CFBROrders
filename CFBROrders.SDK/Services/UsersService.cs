using CFBROrders.SDK.Interfaces;
using CFBROrders.SDK.Interfaces.Services;
using CFBROrders.SDK.Models;
using CFBROrders.SDK.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBROrders.SDK.Services
{
    public class UsersService : IUsersService
    {
        public IUnitOfWork UnitOfWork { get; set; }


        private ILogger _logger;

        public UsersService(IUnitOfWork unitOfWork, ILogger<UsersService> logger)
        {
            UnitOfWork = unitOfWork;
            _logger = logger;
        }

        public List<Users> GetAllUsers(string userId)
        {
            var users = new List<Users>();
            try
            {
                users = ((NPocoUnitOfWork)UnitOfWork).db.Fetch<Users>(
                    @"SELECT 
                        id,
                        uname::text AS uname,
                        platform::text AS platform,
                        join_date,
                        current_team,
                        auth_key::text AS auth_key,
                        overall,
                        turns,
                        game_turns,
                        mvps,
                        streak,
                        awards,
                        role_id,
                        playing_for,
                        array_to_string(past_teams, ',') AS past_teams_string,
                        awards_bak,
                        discord_id,
                        is_alt,
                        must_captcha
                      FROM users"
                ).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all users");
                throw;
            }
            return users;
        }
    }
}
