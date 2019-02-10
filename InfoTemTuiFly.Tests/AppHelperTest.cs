using InfoTemTuiFly.Helper;
using InfoTemTuiFly.Models.Entities;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// AppHelper Test class
    /// </summary>
    public class AppHelperTest
    {
        private Airport Deparature;
        private Airport Destination;

        [SetUp]
        public void Setup()
        {
            Deparature = new Airport
            {
                Name = "Paris orly",
                GpsCoords = "48.727121, 2.365354"
            };
            Destination = new Airport
            {
                Name = "Aéroport international Mohammed V",
                GpsCoords = "33.373486, -7.581042"
            };
        }

        [Test]
        public void AppHelper_Calculate_Distance()
        {
            var distance = AppHelper.GetDistanceFrom(Deparature, Destination);
            Assert.AreEqual(1897.923, distance);
        }
    }
}