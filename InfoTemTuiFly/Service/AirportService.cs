using InfoTemTuiFly.Data;
using InfoTemTuiFly.Models.Entities;
using InfoTemTuiFly.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfoTemTuiFly.Service
{
    /// <summary>
    /// airport Service class
    /// </summary>
    public class AirportService : IAirportService
    {
        /// <summary>
        /// Gets The application context
        /// </summary>
        private readonly ApplicationContext _db;

        /// <summary>
        /// Gets The log service
        /// </summary>
        private readonly ILogger<AirportService> _logger;

        public AirportService(ApplicationContext db, ILogger<AirportService> logger)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// delete an airport
        /// </summary>
        /// <param name="Id">Identifier</param>
        /// <returns>The result</returns>
        public bool Delete(int Id)
        {
            try
            {
                _db.Airport.Remove(GetById(Id));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Failed to delete an airport", new { Id });
                return false;
            }
        }

        /// <summary>
        /// Get all airport
        /// </summary>
        /// <returns>Airport list</returns>
        public List<Airport> GetAll()
        {
            return _db.Airport.ToList();
        }

        /// <summary>
        /// Get an airport by identifier
        /// </summary>
        /// <param name="Id">Identifier</param>
        /// <returns>Airport</returns>
        public Airport GetById(int Id)
        {
            return _db.Airport.Find(Id);
        }

        /// Save an airport ( create / edit )
        /// </summary>
        /// <param name="airport">The airport</param>
        /// <returns>The airport</returns>
        public Airport Save(Airport airport)
        {
            if (airport == null)
                throw new NullReferenceException("airport can not be null");
            try
            {
                if (airport.Id == 0)
                {
                    _db.Airport.Add(airport);
                }
                else
                {
                    _db.Update(airport);
                }
                _db.SaveChanges();

                return airport;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Failed to save an airport", new { airport.Name, airport.GpsCoords });
                return null;
            }
        }
    }
}