namespace InfoTemTuiFly.Models.Entities
{
    /// <summary>
    /// The Flight class
    /// </summary>
    public class Flight
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
        /// Get departure airport identifier ( FK to airport)
        /// </summary>
        public int? DeparatureId { get; set; }

        /// <summary>
        /// Get departure airport
        ///
        public virtual Airport Deparature { get; set; }

        /// <summary>
        /// Get destination airport identifier ( FK to airport)
        /// </summary>
        public int? DestinationId { get; set; }

        /// <summary>
        /// Get destination airport
        ///
        public virtual Airport Destination { get; set; }
    }
}