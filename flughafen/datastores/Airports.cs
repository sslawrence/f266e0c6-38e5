using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;
using System.Collections.ObjectModel;

namespace flughafen.datastores
{
    internal class Airports
    {
        readonly static List<models.Airport> _airports = new List<models.Airport>()
        {
            new models.Airport( "IAD", "Washington Dulles International",    new GeoCoordinate(38.9532, -77.4477)),
            new models.Airport( "BWI", "Baltimore Washington International", new GeoCoordinate(39.1774, -76.6683)),
            new models.Airport( "DFW", "Dallas Fort Worth International",    new GeoCoordinate(32.897480, -97.040443)),
            new models.Airport( "TUS", "Tucson International Airport",       new GeoCoordinate(32.116112, -110.941109))
        };

        public IReadOnlyCollection<models.Airport> GetAllAirports => _airports;

        public models.Airport GetAirportByCode(string code)
        {
            string uppercasedCode = code.ToUpper(); //these are usually all in UPPER case letters by convention (ex: IAD)

            var match = _airports.FirstOrDefault(a => a.Code == uppercasedCode);
            if (match == null)
            {
                throw new DatastoreException($"no airport was found with code '{code}'");
            }

            return match;
        }
        public models.Airport GetAirportByName(string name)
        {
            var match = _airports.FirstOrDefault(a => a.Name.Contains(name));
            if (match == null)
            {
                throw new DatastoreException($"no airport was found with name '{name}; case matters!'");
            }

            return match;
        }
    }
}