using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace flughafen.datastores
{
    internal class Users
    {
        readonly static List<models.User> _users = new List<models.User>()
        {
            new models.User(1, "martin strauss"),
            new models.User(2, "hans gruber"),
            new models.User(3, "lord voldemort"),
            new models.User(4, "theresa may")
        };

        internal IEnumerable<models.User> GetUsersByName(string name)
        {
            //no guarantee a name is unique!
            return _users.Where(u => u.Name == name);
        }

        internal models.User GetUserById(int userId)
        {
            //this won't scale well w/ # of users, but normally this would be bound to a sql table... and this is a simple demo
            var match = _users.FirstOrDefault(u => u.Id == userId); 
            if (match == null)
            {
                throw new DatastoreException($"no user found with id '{userId}' in datastore");
            }

            return match;
        }
    }
}