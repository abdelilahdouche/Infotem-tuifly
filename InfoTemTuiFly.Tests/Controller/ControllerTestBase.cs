using InfoTemTuiFly.Controllers;
using InfoTemTuiFly.Service.Interface;
using NSubstitute;
using NUnit.Framework;

namespace InfoTemTuiFly.Tests.Controller
{
    public class ControllerTestBase
    {
        protected IAirportService _airportService;
        protected IFlightService _flightService;
        protected AirportsController airportsController;
        [SetUp]
        public void Intialize()
        {
            _airportService = Substitute.For<IAirportService>();
            _flightService = Substitute.For<IFlightService>();

            airportsController = new AirportsController(_airportService);
        }
    }
}