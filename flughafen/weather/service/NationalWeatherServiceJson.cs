using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.weather.service
{
    internal class NationalWeatherServiceJson
    {
        //json backing type for nws
        //warning: do not change these names - they must exactly match the values sent by nws!

        public string creationDateLocal { get; set; }

        /// <summary>
        /// merely used for testing purposes - this should be pretty constant ~ "http://weather.gov"
        /// </summary>
        public string credit { get; set; } 

        public CurrentObservations currentobservation;

        internal class CurrentObservations
        {
            /// <summary>
            /// This appears to be in fahrenheit - couldn't locate a unit; NWS doesn't seem to work outside of usa very well anyways so should be safe assumption
            /// </summary>
            public string Temp { get; set; }

            /// <summary>
            /// Actual condition statement - e.g.: mostly cloudy/raining/tornado
            /// </summary>
            public string Weather { get; set; }

            /// <summary>
            /// Assuming miles?
            /// </summary>
            public string Visibility { get; set; }

            /// <summary>
            /// Windspeed; assuming in knots?? maybe in mph? not sure!
            /// </summary>
            public string Winds { get; set; }
        }
    }
}