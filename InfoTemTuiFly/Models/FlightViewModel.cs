using InfoTemTuiFly.Helper;
using InfoTemTuiFly.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTemTuiFly.Models
{
    /// <summary>
    /// Flight view model
    /// </summary>
    public class FlightViewModel
    {
        #region Fields

        /// <summary>
        /// Gets or sets the flight
        /// </summary>
        private Flight _flight;

        /// <summary>
        /// Gets or sets the airports list
        /// </summary>
        private List<Airport> _airportsList;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the flight
        /// </summary>
        public Flight Flight => _flight;

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public int Id
        {
            get { return _flight.Id; }
            set { _flight.Id = value; }
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [Display(Name = "Flight")]
        [MinLength(3, ErrorMessage = "The minimum length of Flight Name field is 3")]
        [MaxLength(50, ErrorMessage = "The maximum length of Flight Name field is 50")]
        public string Name
        {
            get { return _flight.Name; }
            set { _flight.Name = value; }
        }

        /// <summary>
        /// Gets or sets the deparature airport Identifier
        /// </summary>
        [Required]
        [Display(Name = "Deparature Airport")]
        public int? DeparatureId
        {
            get { return _flight.DeparatureId; }
            set { _flight.DeparatureId = value; }
        }

        /// <summary>
        /// Gets or sets the destination airport Identifier
        /// </summary>
        [Required]
        [Display(Name = "Destination Airport")]
        public int? DestinationId
        {
            get { return _flight.DestinationId; }
            set { _flight.DestinationId = value; }
        }

        /// <summary>
        /// Gets or sets the airports list
        /// </summary>
        public List<Airport> AirportsList
        {
            get { return _airportsList; }
            set { _airportsList = value; }
        }

        /// <summary>
        /// Gets the distance
        /// </summary>
        public double? Distance
        {
            get
            {
                return Flight?.Deparature?.GetDistanceFrom(Flight?.Destination);
            }
        }

        /// <summary>
        /// Get the consumption
        /// </summary>
        public double? Consumption
        {
            get
            {
                if (Distance.HasValue)
                    return Distance.Value * Constants.FlightConsumptionPeerKM + Constants.FlightTakeOffConsumptionLiter;
                else
                    return null;
            }
        }

        #endregion Properties

        /// <summary>
        /// Ctor of flight view model
        /// </summary>
        public FlightViewModel()
        {
            _flight = new Flight();
        }

        /// <summary>
        /// Ctor of flight view model
        /// <paramref name="flight">The flight</paramref>
        /// </summary>
        public FlightViewModel(Flight flight)
        {
            _flight = flight;
        }
    }
}