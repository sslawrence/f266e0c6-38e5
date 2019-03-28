using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flughafen.models
{
    public class ModelException : FlughafenBaseException
    {
        public ModelException(string msg) : base(msg) { }
    }
}