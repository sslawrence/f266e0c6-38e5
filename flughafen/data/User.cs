using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.data
{
    [System.Diagnostics.DebuggerDisplay("id = {Id}, name = {Name}")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } //would normally make this own type

        public List<Airport> FavouriteAirports { get; set; }

        public User()
        {
            FavouriteAirports = new List<Airport>();
        }
    }
}