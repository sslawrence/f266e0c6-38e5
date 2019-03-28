using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace flughafen.weather
{
    internal class Report
    {
        public string WeatherSource { get; set; }
        public GeoCoordinate Location { get; set; }
        public Units.Fahrenheit Temperature { get; set; }
        public string Status { get; set; }
        public Units.KnotsPerHour WindSpeed { get; set; }
        public Units.Mile Visiblity { get; set; }
    }
}