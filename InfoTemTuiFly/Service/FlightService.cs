using InfoTemTuiFly.Data;
using InfoTemTuiFly.Models.Entities;
using InfoTemTuiFly.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfoTemTuiFly.Service
{
    /// <summary>
    /// FlightService
    /// </summary>
    public class FlightService : IFlightService
    {
        /// <summary>
        /// The application context
        /// </summary>
        private readonly ApplicationContext _db;

        /// <summary>
        /// Gets The log service
        /// </summary>
        private readonly ILogger<FlightService> _logger;

        public FlightService(ApplicationContext db, ILogger<FlightService> logger)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// delete an flight
        /// </summary>
        /// <param name="Id">Identifier</param>
        /// <returns>The result</returns>
        public bool Delete(int Id)
        {
            try
            {
                _db.Flight.Remove(GetById(Id));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Failed to delete a flight", new { Id });
                return false;
            }
        }

        /// <summary>
        /// Get all flight
        /// </summary>
        /// <returns>List of Flight</returns>
        public List<Flight> GetAll()
        {
            return _db.Flight.Include(f => f.Deparature)
                             .Include(f => f.Destination)
                             .ToList();
        }

        /// <summary>
        /// Get an flight by identifier
        /// </summary>
        /// <param name="Id">Identifier</param>
        /// <returns>flight</returns>
        public Flight GetById(int Id)
        {
            return _db.Flight.Include(f => f.Deparature)
                             .Include(f => f.Destination).SingleOrDefault(m => m.Id == Id);
        }

        /// <summary>
        /// Save a flight ( create / edit )
        /// </summary>
        /// <param name="flight">The flight</param>
        /// <returns>The flight</returns>
        public Flight Save(Flight flight)
        {
            if (flight == null)
                throw new NullReferenceException("airport can not be null");
            try
            {
                if (flight.Id == 0)
                {
                    _db.Add(flight);
                }
                else
                {
                    _db.Update(flight);
                }
                _db.SaveChanges();

                return flight;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Failed to save an airport", new
                {
                    flight.Name,
                    flight.DeparatureId,
                    flight.DestinationId
                });
                return null;
            }
        }
    }
}