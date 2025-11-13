using CFBROrders.SDK.Data_Models;
using CFBROrders.SDK.Interfaces;
using CFBROrders.SDK.Interfaces.Services;
using CFBROrders.SDK.Models;
using CFBROrders.SDK.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBROrders.SDK.Services
{
    public class TeamService : ITeamService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IOperationResult Result { get; set; }   

        private ILogger _logger;

        public TeamService(IUnitOfWork unitOfWork, IOperationResult result, ILogger<TeamService> logger)
        {
            UnitOfWork = unitOfWork;
            Result = result;
            _logger = logger;
        }

        private NPoco.IDatabase Db => ((NPocoUnitOfWork)UnitOfWork).db;

        public double GetTeamStarPowerForTurn(string tname, int season, int day)
        {
            try
            {
                var starPower = Db.SingleOrDefault<double>(
                    @"SELECT starpower
                      FROM statistics WHERE tname = @0 AND season = @1 AND day = @2", tname, season, day);

                return starPower;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching starpower for {tname}: Season {season}, Day {day}");
                throw;
            }
            
        }
    }
}
