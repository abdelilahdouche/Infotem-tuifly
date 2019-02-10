using System.ComponentModel.DataAnnotations;
using InfoTemTuiFly.Models.Entities;

namespace InfoTemTuiFly.Models
{
    /// <summary>
    /// Airport view model
    /// </summary>
    public class AirportViewModel
    {
        /// <summary>
        /// Gets or sets the airport
        /// </summary>
        private Airport _airport;

        /// <summary>
        /// Gets the airport
        /// </summary>
        public Airport Airport => _airport;

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public int Id
        {
            get { return _airport.Id; }
            set { _airport.Id = value; }
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [Display(Name = "Airport")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name
        {
            get { return _airport.Name; }
            set { _airport.Name = value; }
        }

        /// <summary>
        /// Gets or sets the Gps coords
        /// </summary>
        [RegularExpression(@"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?),\s*[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$", ErrorMessage = "The value {0} is not valid for Gps coords")]
        [Display(Name = "GPS coordinates")]
        public string GpsCoords
        {
            get { return _airport.GpsCoords; }
            set { _airport.GpsCoords = value; }
        }

        public AirportViewModel()
        {
            _airport = new Airport();
        }

        public AirportViewModel(Airport airport)
        {
            _airport = airport;
        }
    }
}