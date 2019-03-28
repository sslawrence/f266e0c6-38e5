using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.models
{
    public class Favorite
    {
        public int Number { get; }
        public Airport Airport { get; }

        internal Favorite(int num, Airport airport)
        {
            Number = num;
            Airport = airport;
        }
    }
}