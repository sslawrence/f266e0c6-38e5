using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace flughafen.weather.service
{
    interface IWeatherService
    {
        Report GetCurrentConditions(GeoCoordinate location);
    }
}
