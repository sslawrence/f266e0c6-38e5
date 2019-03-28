using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using proj = flughafen;

namespace flughafen.tests.models
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        [ExpectedException(typeof(proj.models.ModelException))]
        public void exception_on_exceeding_10_favourites()
        {
            var user = new proj.models.User(1, "richard payne");

            //allowed amount
            for (int i = 0; i < 10; i++)
            {
                string airportName = "airport" + i;
                user.AddFavouriteAirport(new proj.models.Airport(i.ToString(), airportName, new System.Device.Location.GeoCoordinate()));
            }

            Assert.IsTrue(user.Favorites.Count == 10); //this is needed to ensure exception is not thrown because of some other problem earlier

            //now try to add 11 - should cause error
            user.AddFavouriteAirport(new proj.models.Airport(11.ToString(), "bad airport", new System.Device.Location.GeoCoordinate()));
        }

        [TestMethod]
        [ExpectedException(typeof(proj.models.ModelException))]
        public void exception_on_duplicate_airport_add()
        {
            var user = new proj.models.User(1, "donald trunk");

            var airport = new proj.models.Airport("IAD", "my own airport", new System.Device.Location.GeoCoordinate());

            user.AddFavouriteAirport(airport); //ok

            Assert.IsTrue(user.Favorites.Count == 1); //same as earlier - since same exception type is used for multiple errors, need to ensure error is not before

            user.AddFavouriteAirport(airport); //duplicate- should fail
        }
    }
}
