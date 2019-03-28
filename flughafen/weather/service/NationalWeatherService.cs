using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace flughafen.weather.service
{
    internal class NationalWeatherService : IWeatherService
    {
        /// <summary>
        /// Returns current conditions for specified location. 
        /// </summary>
        /// <param name="location">Lat + Long for desired location</param>
        /// <exception cref="WeatherException">Error in accessing NWS/parsing response</exception>
        public Report GetCurrentConditions(GeoCoordinate location)
        {
            NationalWeatherServiceJson model = getFromServer(location);

            //WARNING: no explicit markers for units were found; assuming that NWS is in Freedom units!!!
            return new Report()
            {
                WeatherSource = model.credit, //mostly for testing purposes
                Location      = location,
                Status        = model.currentobservation.Weather,
                Temperature   = new Units.Fahrenheit(double.Parse(model.currentobservation.Temp)),
                Visiblity     = new Units.Mile(double.Parse(model.currentobservation.Visibility)),
                WindSpeed     = new Units.KnotsPerHour(double.Parse(model.currentobservation.Winds))
            };
        }

        NationalWeatherServiceJson getFromServer(GeoCoordinate location)
        {
            try
            {
                string url = bindLocationToUrl(location);
                string rawJson = getJsonFromServer(url);
                NationalWeatherServiceJson model = convertToJsonType(rawJson);

                return model;
            }
            catch (Exception ex) //normally i'd narrow this down to more specific types, but this is a rush job
            {
                throw new WeatherException($"error obtaining weather for location {location} from national weather service b/c {ex.Message}", ex);
            }
        }

        string getJsonFromServer(string urlWithLocation)
        {
            using (var client = new System.Net.WebClient())
            {
                client.Headers.Add("user-agent", "a user agent"); //required to prevent forbidden 403; see https://www.weather.gov/documentation/services-web-api
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";

                const string EMPTY_ARGS_NOT_USED = "";
                string json = client.UploadString(urlWithLocation, EMPTY_ARGS_NOT_USED);

                return json;
            }
        }

        NationalWeatherServiceJson convertToJsonType(string jsonReceived)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<NationalWeatherServiceJson>(jsonReceived);
        }

        static string bindLocationToUrl(GeoCoordinate location)
        {
            const string SERVER_URL = "https://forecast.weather.gov/MapClick.php?";
            return $"{SERVER_URL}lat={location.Latitude}&lon={location.Longitude}&FcstType=json";
        }
    }
}