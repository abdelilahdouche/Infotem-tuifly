using InfoTemTuiFly.Service.Interface;
using NUnit.Framework;

namespace InfoTemTuiFly.Tests.Services
{
    public class ServiceBaseTest
    {
        protected IAirportService _airportService;
        protected IFlightService _flightService;

        [SetUp]
        public void Intialize()
        {
        }
    }
}