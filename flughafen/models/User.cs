using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace flughafen.models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } //would recommend making this own type
        public IList<Favorite> Favorites => _favorites.AsReadOnly();

        internal IList<Airport> FavAirports => _favorites.Select(f => f.Airport).ToList().AsReadOnly();
        private readonly List<Favorite> _favorites;

        internal User() { } //needed for json binding apparently

        internal User(int id, string name)
        {
            _favorites = new List<Favorite>();

            Id = id;
            Name = name;
        }

        public void AddFavouriteAirport(Airport airport)
        {
            if (_favorites.Count >= 10)
            {
                throw new ModelException($"you can only store up to 10 favourite airports; you have already saved your allotted 10; you may need to delete some others before trying to add airport '{airport.Name}' again");
            }
            if (_favorites.Exists(a => a.Airport.Code == airport.Code)) //haven't set up equality check for airport :(
            {
                throw new ModelException($"airport {airport.Name} already exists in your favourites list.");
            }

            int nextNumber = _favorites.Count;
            _favorites.Add(new Favorite(nextNumber, airport));
        }

        /// <summary>
        /// Returns favorite by index of entry. 0 based. Useful for walking through a users' favorites.
        /// </summary>
        public Airport GetByFavAirportByFavIndex(int index)
        {
            var match = _favorites.FirstOrDefault(f => f.Number == index);
            if (match == null)
            {
                throw new ModelException($"no favorite saved at index '{index}'");
            }

            return match.Airport;
        }
    }
}