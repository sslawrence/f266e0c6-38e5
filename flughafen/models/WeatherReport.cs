using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace flughafen.models
{
    public class WeatherReport
    {
        public string Location { get; set; }
        public string Temperature { get; set; }
        public string Status { get; set; }

        internal WeatherReport(weather.Report forecast)
        {
            Location = forecast.Location.ToString();
            Temperature = forecast.Temperature.ToPrintable();
            Status = forecast.Status;
        } 
    }
}