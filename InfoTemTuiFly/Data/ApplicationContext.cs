using InfoTemTuiFly.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoTemTuiFly.Data
{
    /// <summary>
    /// the application context(Ef)
    /// </summary>
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the airport dbset
        /// </summary>
        public DbSet<Airport> Airport { get; set; }

        /// <summary>
        /// Gets or sets the airport dbset
        /// </summary>
        public DbSet<Flight> Flight { get; set; }
    }
}