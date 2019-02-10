using InfoTemTuiFly.Data;
using InfoTemTuiFly.Models.Entities;
using InfoTemTuiFly.Service;
using InfoTemTuiFly.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace InfoTemTuiFly.Tests.Services
{
    public class ServiceBaseTest
    {
        protected IAirportService _airportService;
        protected IFlightService _flightService;
        protected ApplicationContext _appContext;

        [SetUp]
        public void Intialize()
        {
            _appContext = Substitute.For<ApplicationContext>();
            var airportlogger = Substitute.For<ILogger<AirportService>>();
            var flightlogger = Substitute.For<ILogger<FlightService>>();

            IQueryable<Airport> airports =
             new List<Airport>
             {
                        new Airport { Id = 1, Name="Paris Orly" },
             }.AsQueryable();

            IQueryable<Flight> flights =
            new List<Flight>
            {
                        new Flight { Id = 1, Name="Paris Orly-Casblanca" },
            }.AsQueryable();

            DbSet<Airport> airportMockSet = Substitute.For<DbSet<Airport>, IQueryable<Airport>>();
            ((IQueryable<Airport>)airportMockSet).Provider.ReturnsForAnyArgs(airports.Provider);
            ((IQueryable<Airport>)airportMockSet).Expression.ReturnsForAnyArgs(airports.Expression);
            ((IQueryable<Airport>)airportMockSet).ElementType.ReturnsForAnyArgs(airports.ElementType);
            ((IQueryable<Airport>)airportMockSet).GetEnumerator().ReturnsForAnyArgs(airports.GetEnumerator());

            DbSet<Flight> flightMockSet = Substitute.For<DbSet<Flight>, IQueryable<Flight>>();
            ((IQueryable<Flight>)flightMockSet).Provider.ReturnsForAnyArgs(flights.Provider);
            ((IQueryable<Flight>)flightMockSet).Expression.ReturnsForAnyArgs(flights.Expression);
            ((IQueryable<Flight>)flightMockSet).ElementType.ReturnsForAnyArgs(flights.ElementType);
            ((IQueryable<Flight>)flightMockSet).GetEnumerator().ReturnsForAnyArgs(flights.GetEnumerator());

            _appContext.Airport = airportMockSet;
            _appContext.Flight = flightMockSet;

            _airportService = new AirportService(_appContext, airportlogger);
            _flightService = new FlightService(_appContext, flightlogger);
        }
    }
}