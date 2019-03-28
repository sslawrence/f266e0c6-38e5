using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.datastores
{
    public class DatastoreException : FlughafenBaseException
    {
        public DatastoreException(string msg) : base(msg) { }
    }
}