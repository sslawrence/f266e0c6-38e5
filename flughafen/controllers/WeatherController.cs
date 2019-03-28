using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flughafen.controllers
{
    [RoutePrefix("api/v1/weather")]
    public class WeatherController : ApiController
    {
        readonly datastores.Airports _airports;
        readonly weather.Forecaster _forecaster;

        public WeatherController() : this(new datastores.Airports(),
                                          weather.Forecaster.AmericanForecaster())
        { }

        internal WeatherController(datastores.Airports airports, weather.Forecaster forecaster)
        {
            _airports = airports;
            _forecaster = forecaster;
        }

        [HttpGet]
        [Route("{airportCode}")]
        public models.WeatherReport GetWeatherForAirport(string airportCode)
        {
            var airport = _airports.GetAirportByCode(airportCode);
            var forecast = _forecaster.GetCurrentConditions(airport.Location);

            return new models.WeatherReport(forecast);
        }

        [HttpGet]
        [Route("{airportCode}/detailed")]
        public models.OpionatedWeatherReport GetOpiononatedWeatherReport(string airportCode)
        {
            var airport = _airports.GetAirportByCode(airportCode);
            var forecast = _forecaster.GetCurrentConditions(airport.Location);

            return new models.OpionatedWeatherReport(forecast);
        }
    }
}
