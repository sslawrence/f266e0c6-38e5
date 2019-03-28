using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flughafen.controllers
{
    [RoutePrefix("api/v1/users")]
    public class UsersController : ApiController
    {
        /*
         * Criticisms: 
         *  I don't like this user controller doing stuff related to airports/weather, but it may make the url a bit more user friendly to clients

         *  I'm also throwing raw exceptions from the business logic (i.e: they will return http error code 500)
         *  It'd be ideal to have the proper http error code bound to the exceptions; that is needed for RESTfulness
         *  
         *  There are a few more complaints but it's very nice weather outside right now and I don't want to be inside anymore :)
         * */

        readonly datastores.Users _users;
        readonly datastores.Airports _airports; 
        readonly weather.Forecaster _forecaster;

        internal UsersController(datastores.Users users, datastores.Airports airports, weather.Forecaster forecaster)
        {
            _users = users;
            _airports = airports;
            _forecaster = forecaster;
        }

        public UsersController() : this(new datastores.Users(), 
                                        new datastores.Airports(), 
                                        weather.Forecaster.AmericanForecaster())
        { }


        [HttpGet]
        [Route("{userId}")]
        public models.User GetUserById(int userId)
        {
            return _users.GetUserById(userId);
        }

        [HttpGet]
        [Route("names/{name}")]
        public IEnumerable<models.User> GetUsersByName(string name) 
        {
            return _users.GetUsersByName(name);//list since names aren't guaranteed to be unique
        }

        [HttpGet]
        [Route("{userId}/favs")]
        public IEnumerable<models.Airport> GetAllFavorites(int userId)
        {
            return _users.GetUserById(userId).FavAirports;
        }

        [HttpGet]
        [Route("{userId}/favs/{favnum}")]
        public models.Airport GetFavoriteByIndex(int userId, int favnum)
        {
            var user = _users.GetUserById(userId);
            return user.GetByFavAirportByFavIndex(favnum);
        }
        [HttpGet]
        [Route("{userId}/favs/{favnum}/weather")]
        public models.WeatherReport GetWeatherForFavNum(int userId, int favnum)
        {
            var user = _users.GetUserById(userId);
            var airport = user.GetByFavAirportByFavIndex(favnum);
            var forecast = _forecaster.GetCurrentConditions(airport.Location);

            return new models.WeatherReport(forecast);
        }

        [HttpGet]
        [Route("{userId}/favs/{favnum}/advanceWeather")]
        public models.OpionatedWeatherReport GetAdvanceWeatherForFavNum(int userId, int favnum)
        {
            var user = _users.GetUserById(userId);
            var airport = user.GetByFavAirportByFavIndex(favnum);
            var forecast = _forecaster.GetCurrentConditions(airport.Location);

            return new models.OpionatedWeatherReport(forecast);
        }

        [HttpPost]
        [Route("{userId}/{airportCode}")]
        public HttpResponseMessage AddFavorite(int userId, string airportCode)
        {
            var user = _users.GetUserById(userId);
            var airport = _airports.GetAirportByCode(airportCode);

            user.AddFavouriteAirport(airport);

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}