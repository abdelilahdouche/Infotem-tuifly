using InfoTemTuiFly.Models.Entities;
using System.Collections.Generic;

namespace InfoTemTuiFly.Service.Interface
{
    public interface IFlightService
    {
        /// <summary>
        /// Save a flight ( create / edit )
        /// </summary>
        /// <param name="flight">The flight</param>
        /// <returns>The flight</returns>
        Flight Save(Flight flight);

        /// <summary>
        /// Get all flight
        /// </summary>
        /// <returns>List of Flight</returns>
        List<Flight> GetAll();

        /// <summary>
        /// Get an flight by identifier
        /// </summary>
        /// <param name="Id">Identifier</param>
        /// <returns>Airport</returns>
        Flight GetById(int Id);

        /// <summary>
        /// delete a flight
        /// </summary>
        /// <param name="Id">Identifier</param>
        /// <returns>The result</returns>
        bool Delete(int Id);
    }
}