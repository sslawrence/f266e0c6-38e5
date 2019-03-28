using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace flughafen.data
{
    [System.Diagnostics.DebuggerDisplay("name = {Name}, loc = {Location}")]
    public class Airport
    {
        public string Name { get; set; }
        public GeoCoordinate Location { get; set; }
    }
}