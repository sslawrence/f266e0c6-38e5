using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace flughafen.models
{
    [System.Diagnostics.DebuggerDisplay("code = {Code}, name = {Name}")]
    public class Airport
    {
        /// <summary> 3 letter, IATA airport code(ex: IAD) </summary>
        public string Code { get; }
        /// <summary> Name of airport (ex: Dulles Washgington International) </summary>
        public string Name { get; }
        /// <summary> Lat and Long of the airport.</summary>
        public string Coordinates => Location.ToString();
        
        //don't like exposing this to json serializer, since it has extra stuff we don't want exposed; normally this would be taken care of by having separate data and model classes
        internal GeoCoordinate Location { get; }

        public Airport(string code, string name, GeoCoordinate location)
        {
            Code = code;
            Name = name;
            Location = location;
        }
    }
}