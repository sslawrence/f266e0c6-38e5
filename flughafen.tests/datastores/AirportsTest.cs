using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace flughafen.tests.datastores
{
    [TestClass]
    public class AirportsTest
    {
        [TestMethod]
        public void lower_case_airport_code_returns_match()
        {
            var airports = new flughafen.datastores.Airports();

            const string CODE_FOR_DULLES_LOWER_CASE = "iad";
            var match = airports.GetAirportByCode(CODE_FOR_DULLES_LOWER_CASE);

            Assert.IsNotNull(match); //may not really be needed, but release build might cause skipping of previous func since no value is captured otherwise
        }
    }
}
