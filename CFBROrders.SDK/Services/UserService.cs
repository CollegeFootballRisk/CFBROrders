using CFBROrders.SDK.Data_Models;
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
    public class UserService : IUserService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IOperationResult Result { get; set; }

        private ILogger _logger;

        public UserService(IUnitOfWork unitOfWork,  IOperationResult result, ILogger<UserService> logger)
        {
            UnitOfWork = unitOfWork;
            Result = result;
            _logger = logger;
        }

        private NPoco.IDatabase Db => ((NPocoUnitOfWork)UnitOfWork).db;

        public List<User> GetAllUsers(string userId)
        {
            var users = new List<User>();
            try
            {
                users = Db.Fetch<User>(
                    @"SELECT *
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

        public User GetUserByPlatformAndUsername(string platform, string uname)
        {
            var user = new User();

            try
            {
                user = Db.SingleOrDefault<User>(
                    @"SELECT *
                      FROM users
                    WHERE platform = @0 
                    AND split_part(uname, '$', 1) = @1",
                    platform, uname
                );

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting user with platform: {platform} and uname: {uname}");
                throw;
            }
            _logger.LogInformation($"Success getting user with platform: {platform} and uname: {uname}");
            
            return user;
        }
    }
}
