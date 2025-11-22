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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CFBROrders.SDK.Services
{
    public class UserOrderService(IUnitOfWork unitOfWork, IOperationResult result, ILogger<UserOrderService> logger) : IUserOrderService
    {
        public IUnitOfWork UnitOfWork { get; set; } = unitOfWork;
        public IOperationResult Result { get; set; } = result;

        private readonly ILogger _logger = logger;

        private NPoco.IDatabase Db => ((NPocoUnitOfWork)UnitOfWork).Db;

        public UserOrder GetUserOrder(string username, int seasonId, int turnId)
        {
            Result.Reset();

            UserOrder userOrder;

            try
            {
                userOrder = Db.SingleOrDefault<UserOrder>(
                    @"SELECT *
                      FROM user_orders WHERE username = @0
                      AND season_id = @1
                      AND turn_id = @2", username, seasonId, turnId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching user order for {username} on Season {seasonId} turn {turnId}");

                Result.GetException(ex);

                throw;
            }
            _logger.LogInformation($"Fetched user order for {username} on Season {seasonId} turn {turnId}");

            return userOrder;
        }

        public IOperationResult InsertUserOrder(UserOrder userOrder)
        {
            Result.Reset();

            try
            {
                UnitOfWork.BeginTransaction();

                Db.Insert(userOrder);

                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();

                _logger.LogError(ex, $"Error inserting user Order for {userOrder}");
               
                Result.GetException(ex);
                
                throw;
            }
            _logger.LogInformation($"Inserted User Order: TerritoryId={userOrder.TerritoryId}, TeamId={userOrder.Team}, SeasonId = {userOrder.SeasonId}, Day = {userOrder.TurnId}");

            return Result;
        }

        public IOperationResult UpdateUserOrder(UserOrder userOrder)
        {
            Result.Reset();

            try
            {
                UnitOfWork.BeginTransaction();

                Db.Update(userOrder);

                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();

                _logger.LogError(ex, $"Error updating user Order for {userOrder}");

                Result.GetException(ex);

                throw;
            }
            _logger.LogInformation($"Updated User Order: TerritoryId={userOrder.TerritoryId}, TeamId={userOrder.Team}, SeasonId = {userOrder.SeasonId}, Day = {userOrder.TurnId}");

            return Result;
        }
    }
}
