using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.models
{
    public class ClothingTips
    {
        public bool WearACoat { get; set; }
        public bool TakeAnUmbrella { get; set; }

        internal ClothingTips() { } //needed for json binding
         
        internal ClothingTips(weather.Report report)
        {
            TakeAnUmbrella = isItRaining(report.Status);
            WearACoat = isItCold(report.Temperature);
        }

        static bool isItRaining(string condition)
        {
            string loweredCondition = condition.ToLower();

            if (loweredCondition.Contains("showers"))
            {
                return true;
            }
            if (loweredCondition.Contains("t-storms"))
            {
                return true;
            }

            //what about snow?

            return false;
        }

        static bool isItCold(weather.Units.Fahrenheit temp)
        {
            if (temp.Value < 70) //i've been told this is how I should feel
            {
                return true;
            }

            return false;
        }
    }
}