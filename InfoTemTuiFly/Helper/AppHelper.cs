using GeoCoordinatePortable;
using InfoTemTuiFly.Models.Entities;
using System;
using System.Globalization;

namespace InfoTemTuiFly.Helper
{
    /// <summary>
    /// Application Helper
    /// </summary>
    public static class AppHelper
    {
        /// <summary>
        /// Get distance between two airport
        /// </summary>
        /// <param name="airportFrom">Departure airport</param>
        /// <param name="airportTo">Destination airport</param>
        /// <returns>Disatnce</returns>
        public static double GetDistanceFrom(this Airport airportFrom, Airport airportTo)
        {
            if (airportFrom == null || airportTo == null)
                return 0;
            float lat, lon;
            GeoCoordinate pFrom = null, pTo = null;

            var coords = airportFrom.GpsCoords.Split(',');

            if (coords != null && coords.Length == 2)
            {
                lat = float.Parse(coords[0], CultureInfo.InvariantCulture.NumberFormat);
                lon = float.Parse(coords[1], CultureInfo.InvariantCulture.NumberFormat);
                pFrom = new GeoCoordinate(lat, lon);
            }

            coords = airportTo.GpsCoords.Split(',');

            if (coords != null && coords.Length == 2)
            {
                lat = float.Parse(coords[0], CultureInfo.InvariantCulture.NumberFormat);
                lon = float.Parse(coords[1], CultureInfo.InvariantCulture.NumberFormat);
                pTo = new GeoCoordinate(lat, lon);
            }
            if (pTo != null && pFrom != null)
                return Math.Round(pFrom.GetDistanceTo(pTo) / Constants.MeterPeerKM, 3);
            else
                return -1;
        }
    }
}