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
    public class OrderAllocationService(IUnitOfWork unitOfWork, IOperationResult result, ILogger<OrderAllocationService> logger) : IOrderAllocationService
    {
        public IUnitOfWork UnitOfWork { get; set; } = unitOfWork;
        public IOperationResult Result { get; set; } = result;

        private readonly ILogger _logger = logger;

        private NPoco.IDatabase Db => ((NPocoUnitOfWork)UnitOfWork).Db;

        public IOperationResult InsertOrderAllocation(OrderAllocation orderAllocation)
        {
            Result.Reset();

            try
            {
                UnitOfWork.BeginTransaction();

                Db.Insert(orderAllocation);

                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();

                _logger.LogError(ex, $"Error inserting single order allocation for {orderAllocation}");
               
                Result.GetException(ex);
                
                throw;
            }
            _logger.LogInformation($"Inserted Order Allocation: TerritoryId={orderAllocation.TerritoryId}, TeamId={orderAllocation.TeamId}");

            return Result;
        }

        public void InsertOrderAllocationWithoutTransaction(OrderAllocation orderAllocation)
        {
            Db.Insert(orderAllocation);
        }

        public IOperationResult InsertOrderAllocations(List<OrderAllocation> orderAllocations)
        {
            Result.Reset();

            try
            {
                UnitOfWork.BeginTransaction();

                foreach (var allocation in orderAllocations)
                {
                    InsertOrderAllocationWithoutTransaction(allocation);
                }

                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();

                _logger.LogError(ex, "Error batch inserting order allocations. Count={Count}", orderAllocations.Count);

                Result.GetException(ex);
                throw;
            }
            _logger.LogInformation("Batch insert successful: {Count} order allocations", orderAllocations.Count);

            return Result;
        }
    }
}
