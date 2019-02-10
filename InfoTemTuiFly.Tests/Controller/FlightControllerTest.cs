using InfoTemTuiFly.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace InfoTemTuiFly.Tests.Controller
{
    public class FlightControllerTest : ControllerTestBase
    {
        [Test]
        public void FlightControllerTest_GetAll_Test()
        {
            //Arrange
            _flightService.GetAll().Returns(new List<Flight>());

            //Act
            var result = flightsController.Index();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [Test]
        public void FlightControllerTest_GetAll_Create()
        {
            //Arrange
            //Act
            var result = flightsController.Create();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [Test]
        public void flightsControllerTest_GetAll_Create_Flight()
        {
            //Arrange
            var flight = new Flight() { Id = 1, Name = "Airport" };
            _flightService.Save(flight).Returns(flight);
            //Act
            var result = flightsController.Create(new Models.FlightViewModel(flight));

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
        }

        [Test]
        public void FlightControllerTest_Details_Id_Null_Test()
        {
            //Arrange
            //Act
            var result = flightsController.Details(null);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [Test]
        public void FlightControllerTest_Details_Id_NotNull_NotFound_Test()
        {
            //Arrange
            Flight flight = null;
            _flightService.GetById(Arg.Any<int>()).Returns(flight);

            //Act
            var result = flightsController.Details(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }

        [Test]
        public void FlightControllerTest_Details_Id_NotNull_Found_Test()
        {
            //Arrange
            var flight = new Flight() { Id = 1 };
            _flightService.GetById(Arg.Any<int>()).Returns(flight);

            //Act
            var result = flightsController.Details(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        // The Details Method and Edit are the some
        // Edit with args is the some as Create with args
    }
}