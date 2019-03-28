using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace flughafen.tests.weather
{
    [TestClass]
    public class NwsTest
    {
        [TestMethod]
        public void weather_source_value_matches_standard_expected()
        {
            //the weather obviously changes constantly, but the credit field in the json should be pretty constant at containing 'http://weather.gov'
            //is used as a very crude, high level test to ensure nws coms and parsing works
            var nws = new flughafen.weather.service.NationalWeatherService();

            var HOUSTON_INTERNATIONAL_AIRPORT_COORDS = new System.Device.Location.GeoCoordinate(29.98, -95.36);
            var weather = nws.GetCurrentConditions(HOUSTON_INTERNATIONAL_AIRPORT_COORDS);

            Assert.IsTrue(weather.WeatherSource.Contains("weather.gov"));
        }
    }
}
