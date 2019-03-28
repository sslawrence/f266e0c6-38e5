using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flughafen.controllers
{
    [RoutePrefix("api/v1/airports")]
    public class AirportsController : ApiController
    {
        readonly datastores.Airports _airports;

        public AirportsController() : this(new datastores.Airports())
        { }

        internal AirportsController(datastores.Airports airports)
        {
            _airports = airports;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<models.Airport> GetAll() //for some reason, this query fails in chrome + ff, but it work in Postman/Fiddler
        {
            return _airports.GetAllAirports;
        }

        [HttpGet]
        [Route("{airportName}")]
        public models.Airport GetByName(string airportName)
        {
            return _airports.GetAirportByName(airportName);
        }
    }
}
