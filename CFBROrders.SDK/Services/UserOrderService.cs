/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using CFBROrders.SDK.Data_Models;
using CFBROrders.SDK.Interfaces;
using CFBROrders.SDK.Interfaces.Services;
using CFBROrders.SDK.Models;
using CFBROrders.SDK.Repositories;
using Microsoft.Extensions.Logging;

namespace CFBROrders.SDK.Services
{
    public class UserOrderService(IUnitOfWork unitOfWork, IOperationResult result,
        ILogger<UserOrderService> logger, IOrderAllocationService orderAllocationService) : IUserOrderService
    {
        public IUnitOfWork UnitOfWork { get; set; } = unitOfWork;
        public IOperationResult Result { get; set; } = result;

        private readonly ILogger _logger = logger;

        public IOrderAllocationService OrderAllocationService { get; set; } = orderAllocationService;

        private NPoco.IDatabase Db => ((NPocoUnitOfWork)UnitOfWork).Db;

        public UserOrder GetSingleUserOrder(string username, int seasonId, int turnId)
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

        public List<UserOrder> GetAllUserOrdersByTurn(int seasonId, int turnId)
        {
            Result.Reset();

            List<UserOrder> orders;

            try
            {
                orders = Db.Fetch<UserOrder>(
                    @"SELECT * 
              FROM user_orders 
              WHERE season_id = @0 AND turn_id = @1",
                    seasonId, turnId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching user orders for Season {seasonId} Turn {turnId}");

                Result.GetException(ex);
                throw;
            }
            _logger.LogInformation($"Fetched {orders.Count} user orders for Season {seasonId} Turn {turnId}");

            return orders;
        }

        public IOperationResult InsertUserOrder(UserOrder userOrder)
        {
            Result.Reset();

            try
            {
                UnitOfWork.BeginTransaction();

                Db.Insert(userOrder);

                OrderAllocationService.RecalculateAllocationForTerritory(userOrder.SeasonId, userOrder.TurnId, userOrder.TerritoryId!.Value);

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

                var oldUserOrder = GetSingleUserOrder(userOrder.Username, userOrder.SeasonId, userOrder.TurnId);

                var oldTerritoryId = oldUserOrder.TerritoryId;

                Db.Update(userOrder);

                OrderAllocationService.RecalculateAllocationForTerritory(userOrder.SeasonId, userOrder.TurnId, userOrder.TerritoryId!.Value);

                if (oldTerritoryId.HasValue && oldTerritoryId.Value != userOrder.TerritoryId.Value)
                {
                    OrderAllocationService.RecalculateAllocationForTerritory(
                        userOrder.SeasonId, userOrder.TurnId, oldTerritoryId.Value);
                }

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
