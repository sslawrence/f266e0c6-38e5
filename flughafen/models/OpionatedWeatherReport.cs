using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.models
{
    public class OpionatedWeatherReport
    {
        public WeatherReport Conditions { get; }
        public ClothingTips DressRecommendations { get; }
        public TurbulenceReport FlightConditions { get; }

        internal OpionatedWeatherReport(weather.Report report)
        {
            Conditions = new WeatherReport(report);
            DressRecommendations = new ClothingTips(report);
            FlightConditions = new TurbulenceReport(report);
        }
    }
}