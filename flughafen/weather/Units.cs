using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.weather
{
    internal class Units
    {
        //why all this explicitness? see here https://en.wikipedia.org/wiki/Mars_Climate_Orbiter

        internal class UnitBase
        {
            public double Value { get; }
            public string Unit { get; }

            protected UnitBase(double value, string unit)
            {
                Value = value;
                Unit = unit;
            }

            public string ToPrintable() => $"{Value}{Unit}"; //ex: 99C or 99F or 81Knots
        }

        public class Fahrenheit : Units.UnitBase
        {
            internal Fahrenheit(double value) : base(value, "F")
            { }
        }
        public class KnotsPerHour : Units.UnitBase
        {
            internal KnotsPerHour(double speed) : base(speed, "knots")
            { }
        }
        public class Mile : UnitBase
        {
            internal Mile(double miles) : base(miles, "miles")
            { }
        }
    }
}