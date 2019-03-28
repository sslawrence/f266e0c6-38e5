using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace flughafen.weather
{
    internal class Forecaster
    {
        /// <summary> Convenience creator for an American locale that can use the NWS. </summary>
        public static Forecaster AmericanForecaster() => new Forecaster(new service.NationalWeatherService());


        readonly service.IWeatherService _service;

        public Forecaster(service.IWeatherService service)
        {
            _service = service;
        }

        public Report GetCurrentConditions(GeoCoordinate location)
        {
            return _service.GetCurrentConditions(location);
        }
    }
}