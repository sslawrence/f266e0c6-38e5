using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.models
{
    public class OpionatedWeatherReport
    {
        public WeatherReport Conditions { get; set; }
        public ClothingTips DressRecommendations { get; set; }
        public TurbulenceReport FlightConditions { get; set; }

        internal OpionatedWeatherReport() { }  //model binding requirement

        internal OpionatedWeatherReport(weather.Report report)
        {
            Conditions = new WeatherReport(report);
            DressRecommendations = new ClothingTips(report);
            FlightConditions = new TurbulenceReport(report);
        }
    }
}