using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.models
{

    //if this were prod, this class would need to be refacced and tested

    public class TurbulenceReport
    {
        public bool ShouldCheckForFlightDelays { get; set; }
        public string Why { get; set; }

        readonly bool _isWindy;
        readonly bool _isVisibilityImpaired;

        internal TurbulenceReport() { } //needed for json binding

        internal TurbulenceReport(weather.Report forecast)
        {
            if (isItWindy(forecast.WindSpeed))
            {
                _isWindy = true;
            }
            if (isVisiblityImpaired(forecast.Visiblity))
            {
                _isVisibilityImpaired = true;
            }

            Why = parseWhy(_isWindy, _isVisibilityImpaired);
        }

        static string parseWhy(bool isWindy, bool isVisbilityImpaired)
        {
            if (!isWindy && !isVisbilityImpaired)
            {
                return "Things look peachy! Your flight should be on time!";
            }

            var messages = new List<string>(2);

            if (isWindy)
            {
                messages.Add("windy");
            }
            if (isVisbilityImpaired)
            {
                messages.Add("visiblity is impaired");
            }

            return makeSentenceFromMessages(messages);
        }

        static string makeSentenceFromMessages(List<string> messages)
        {
            bool isFirst = false;
            var sb = new System.Text.StringBuilder("It's ");
            foreach (string message in messages)
            {
                if (!isFirst)
                {
                    sb.Append(", and ");
                }

                sb.Append(message);
                isFirst = true;
            }

            return sb.ToString();
        }

        static bool isItWindy(weather.Units.KnotsPerHour windSpeed)
        {
            //note: should account for gusts!

            //cutoff recom from https://www.aopa.org/news-and-media/all-news/1998/march/pilot/too-windy
            var TURBLUENCE_CUTOFF = new weather.Units.KnotsPerHour(15); 

            if (windSpeed.Value> TURBLUENCE_CUTOFF.Value)  
            {
                return true;
            }

            return false;
        }
        static bool isVisiblityImpaired(weather.Units.Mile visiblity)
        {
            //obtained from vfr recoms; commercials aren't probably affected by this however... see https://www.aopa.org/news-and-media/all-news/2008/april/flight-training-magazine/basic-vfr
            var VFR_VISIBLITY_CUTOFF = new weather.Units.Mile(3);

            if (visiblity.Value < VFR_VISIBLITY_CUTOFF.Value)
            {
                return true;
            }

            return false;
        }
    }
}