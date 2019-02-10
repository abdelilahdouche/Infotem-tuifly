namespace InfoTemTuiFly.Models.Entities
{
    /// <summary>
    /// Airport Class
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the latitude
        /// </summary>
        public string GpsCoords { get; set; }
    }
}