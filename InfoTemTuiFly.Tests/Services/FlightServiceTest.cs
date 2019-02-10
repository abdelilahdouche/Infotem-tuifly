using InfoTemTuiFly.Models.Entities;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;

namespace InfoTemTuiFly.Tests.Services
{
    internal class FlightServiceTest : ServiceBaseTest
    {
        [Test]
        public void FlightServiceTest_GetAll()
        {
            //Arrange
            //Act
            var result = _flightService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            ((IQueryable<Flight>)_appContext.Flight).Received().ToList();
        }

        [Test]
        public void FlightServiceTest_GetById()
        {
            //Arrange
            //Act
            var result = _flightService.GetById(1);

            //Assert
            ((IQueryable<Flight>)_appContext.Flight).ReceivedWithAnyArgs().SingleOrDefault();
        }

        [Test]
        public void FlightServiceTest_Save_Null()
        {
            //Arrange
            Flight flight = null;
            //Act
            var result = Assert.Throws<ArgumentNullException>(() => _flightService.Save(flight));

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void FlightServiceTest_Save_New()
        {
            //Arrange
            var flight = new Flight() { Id = 0, Name = "Flight" };
            //Act
            var result = _flightService.Save(flight);

            //Assert
            Assert.NotNull(result);
            _appContext.Received().Add(Arg.Any<Flight>());
            _appContext.DidNotReceive().Update(Arg.Any<Flight>());
        }

        [Test]
        public void FlightServiceTest_Save_Exist()
        {
            //Arrange
            var flight = new Flight() { Id = 1, Name = "Flight" };
            //Act
            var result = _flightService.Save(flight);

            //Assert
            Assert.NotNull(result);
            _appContext.DidNotReceive().Add(Arg.Any<Flight>());
            _appContext.Received().Update(Arg.Any<Flight>());
        }

        [Test]
        public void FlightServiceTest_Delete()
        {
            //Arrange
            var flight = new Flight() { Id = 1, Name = "Flight" };
            //Act
            var result = _flightService.Delete(1);

            //Assert
            Assert.IsTrue(result);
            _appContext.Flight.ReceivedWithAnyArgs().Remove(flight);
        }
    }
}