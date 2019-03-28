using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.models
{
    public class Favorite
    {
        public int Number { get; set; }
        public Airport Airport { get; set; }

        internal Favorite() { } //needed for binding

        internal Favorite(int num, Airport airport)
        {
            Number = num;
            Airport = airport;
        }
    }
}