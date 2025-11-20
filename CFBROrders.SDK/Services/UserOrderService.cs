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
    }
}
