using InfoTemTuiFly.Models.Entities;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;

namespace InfoTemTuiFly.Tests.Services
{
    /// <summary>
    /// Airport Service test
    /// </summary>
    public class AirportServiceTest : ServiceBaseTest
    {
        [Test]
        public void AirportServiceTest_GetAll()
        {
            //Arrange
            //Act
            var result = _airportService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            ((IQueryable<Airport>)_appContext.Airport).Received().ToList();
        }

        [Test]
        public void AirportServiceTest_GetById()
        {
            //Arrange
            //Act
            var result = _airportService.GetById(1);

            //Assert
            _appContext.Airport.Received().Find(Arg.Any<int>());
        }

        [Test]
        public void AirportServiceTest_Save_Null()
        {
            //Arrange
            Airport airport = null;
            //Act
            var result = Assert.Throws<ArgumentNullException>(() => _airportService.Save(airport));

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void AirportServiceTest_Save_New()
        {
            //Arrange
            var airport = new Airport() { Id = 0, Name = "Airport" };
            //Act
            var result = _airportService.Save(airport);

            //Assert
            Assert.NotNull(result);
            _appContext.Airport.Received().Add(Arg.Any<Airport>());
            _appContext.DidNotReceive().Update(Arg.Any<Airport>());
        }

        [Test]
        public void AirportServiceTest_Save_Exist()
        {
            //Arrange
            var airport = new Airport() { Id = 1, Name = "Airport" };
            //Act
            var result = _airportService.Save(airport);

            //Assert
            Assert.NotNull(result);
            _appContext.Airport.DidNotReceive().Add(Arg.Any<Airport>());
            _appContext.Received().Update(Arg.Any<Airport>());
        }

        [Test]
        public void AirportServiceTest_Delete()
        {
            //Arrange
            var airport = new Airport() { Id = 1, Name = "Airport" };
            _airportService.GetById(Arg.Is<int>(a => a > 0)).Returns(airport);
            //Act
            var result = _airportService.Delete(1);

            //Assert
            Assert.IsTrue(result);
            _appContext.Airport.Received().Remove(airport);
        }
    }
}