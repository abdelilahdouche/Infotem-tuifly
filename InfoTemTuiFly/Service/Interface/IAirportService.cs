using InfoTemTuiFly.Models.Entities;
using System.Collections.Generic;

namespace InfoTemTuiFly.Service.Interface
{
    /// <summary>
    /// the airport service interface
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Save an airport ( create / edit )
        /// </summary>
        /// <param name="airport">The airport</param>
        /// <returns>The airport</returns>
        Airport Save(Airport airport);

        /// <summary>
        /// Get all airport
        /// </summary>
        /// <returns>Airport list</returns>
        List<Airport> GetAll();

        /// <summary>
        /// Get an airport by identifier
        /// </summary>
        /// <param name="Id">Identifier</param>
        /// <returns>Airport</returns>
        Airport GetById(int Id);

        /// <summary>
        /// delete an airport
        /// </summary>
        /// <param name="Id">Identifier</param>
        /// <returns>The result</returns>
        bool Delete(int Id);
    }
}