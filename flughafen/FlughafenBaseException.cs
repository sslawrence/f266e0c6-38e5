using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen
{
    public class FlughafenBaseException : Exception
    {
        public FlughafenBaseException(string msg) : base(msg) { }
        public FlughafenBaseException(string msg, Exception ex) : base(msg, ex) { }
    }
}