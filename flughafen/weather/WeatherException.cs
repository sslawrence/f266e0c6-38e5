using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.weather
{
    public class WeatherException : FlughafenBaseException
    {
        public WeatherException(string msg, Exception ex) : base(msg, ex){}
    }
}