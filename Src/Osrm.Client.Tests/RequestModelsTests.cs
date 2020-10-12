using Microsoft.VisualStudio.TestTools.UnitTesting;
using Osrm.Client.Models;
using Osrm.Client.Models.Requests;

namespace Osrm.Client.Tests
{
    [TestClass]
    public class RequestModelsTests
    {
        [TestMethod]
        public void RouteRequest_Defaults()
        {
            var r = new RouteRequest();
            Assert.AreEqual<bool>(false, r.Alternative);
            Assert.AreEqual<bool>(false, r.Steps);
            Assert.AreEqual<string>("polyline6", r.Geometries);
            Assert.AreEqual<string>("simplified", r.Overview);
            Assert.AreEqual<string>("default", r.ContinueStraight);
        }

        [TestMethod]
        public void TableRequest_Defaults()
        {
            var r = new TableRequest();
            Assert.IsNotNull(r.Sources);
            Assert.IsNotNull(r.Destinations);
        }

        [TestMethod]
        public void MatchRequest_Defaults()
        {
            var r = new MatchRequest();
            Assert.AreEqual<bool>(false, r.Steps);
            Assert.AreEqual<string>("polyline6", r.Geometries);
            Assert.AreEqual<string>("simplified", r.Overview);
            Assert.IsNotNull(r.Timestamps);
        }

        [TestMethod]
        public void NearestRequest_Defaults()
        {
            var r = new NearestRequest();
            Assert.AreEqual<uint>(1, r.Number);
        }

        [TestMethod]
        public void Location_Equals()
        {
            var a1 = new Location(52.542648m, 13.393252m);
            var a2 = new Location(52.542648m, 13.393252m);
            Assert.IsTrue(a1 == a2);
            Assert.IsTrue(a1.Equals(a2));

            var b1 = new Location(12.542648m, 13.393252m);
            var b2 = new Location(12.542648m, 13.393252m);
            Assert.IsTrue(b1 == b2);
            Assert.IsTrue(b1.Equals(b2));
        }

        [TestMethod]
        public void TripRequest_Defaults()
        {
            var r = new TripRequest();
            Assert.AreEqual<bool>(false, r.Annotate);
            Assert.AreEqual<bool>(false, r.Steps);
            Assert.AreEqual<string>("polyline6", r.Geometries);
            Assert.AreEqual<string>("simplified", r.Overview);
        }

        [TestMethod]
        public void BaseRequest_Defaults()
        {
            var r = new TripRequest();

            // test common base request items
            Assert.AreEqual<bool>(false, r.SendCoordinatesAsPolyline);
            Assert.IsNotNull(r.Coordinates);
            Assert.IsNotNull(r.Bearings);
            Assert.IsNotNull(r.Radiuses);
            Assert.IsNotNull(r.Hints);

        }
    }
}