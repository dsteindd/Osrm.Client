using Microsoft.VisualStudio.TestTools.UnitTesting;
using Osrm.Client.Models;
using System.Net.Http;
using Osrm.Client.Models.Requests;

namespace Osrm.Client.Tests
{
    [TestClass]
    public class ResponseTests
    {
        protected Osrm5x osrm = new Osrm5x(new HttpClient(), "http://router.project-osrm.org/");

        [TestMethod]
        public void Route_Response()
        {
            var locations = new Location[] {
                new Location(52.503033m, 13.420526m),
                new Location(52.516582m, 13.429290m),
            };

            var result = osrm.Route(locations).GetAwaiter().GetResult();

            Assert.AreEqual<string>("Ok", result.Code);
            Assert.IsTrue(result.Routes.Length > 0);
            Assert.IsTrue(result.Waypoints.Length > 0);
            Assert.IsTrue(result.Routes[0].Legs.Length > 0);

            var result2 = osrm.Route(new RouteRequest()
            {
                Coordinates = locations,
                Alternative = false,
                Overview = "full",
                Annotations = new []{"distance", "duration", "speed"}
            }).GetAwaiter().GetResult();

            Assert.AreEqual<string>("Ok", result2.Code);
            Assert.IsTrue(result2.Routes.Length > 0);
            Assert.IsTrue(result2.Waypoints.Length > 0);
            Assert.IsTrue(result2.Routes[0].Legs.Length > 0);

            var result3 = osrm.Route(new RouteRequest()
            {
                Coordinates = locations,
                Alternative = true
            }).GetAwaiter().GetResult();

            Assert.AreEqual<string>("Ok", result3.Code);
            Assert.IsTrue(result3.Routes.Length > 0);
            Assert.IsTrue(result3.Waypoints.Length > 0);
            Assert.IsTrue(result3.Routes[0].Legs.Length > 0);
        }

        [TestMethod]
        public void Table_Response()
        {
            var locations = new Location[] {
                new Location(52.554070m, 13.160621m),
                new Location(52.431272m, 13.720654m),
                new Location(52.554070m, 13.720654m),
                new Location(52.554070m, 13.160621m),
            };

            var result = osrm.Table(locations).GetAwaiter().GetResult();
            Assert.AreEqual<string>("Ok", result.Code);
            Assert.AreEqual<int>(4, result.Durations.Length);
            Assert.AreEqual<int>(4, result.Durations[0].Length);
            Assert.AreEqual<int>(4, result.Durations[1].Length);
            Assert.AreEqual<int>(4, result.Durations[2].Length);
            Assert.AreEqual<int>(4, result.Durations[3].Length);

            var srcAndDests = new Location[] {
                new Location(52.554070m, 13.160621m),
                new Location(52.431272m, 13.720654m),
                new Location(52.554070m, 13.720654m),
                new Location(52.554070m, 13.160621m),
            };

            var result2 = osrm.Table(new TableRequest()
            {
                Coordinates = srcAndDests,
                Sources = new uint[] { 0 },
                Destinations = new uint[] { 1, 2, 3 }
            }).GetAwaiter().GetResult();

            Assert.AreEqual<string>("Ok", result.Code);
            Assert.AreEqual<int>(1, result2.Durations.Length);
            Assert.AreEqual<int>(3, result2.Durations[0].Length);
        }

        [TestMethod]
        public void Match_Response()
        {
            var locations = new Location[] {
                new Location(52.542648m, 13.393252m),
                new Location(52.543079m, 13.394780m),
                new Location(52.542107m, 13.397389m)
            };

            var req = new MatchRequest()
            {
                Coordinates = locations,
                Timestamps = new int[] { 1424684612, 1424684616, 1424684620 }
            };

            var result = osrm.Match(req).GetAwaiter().GetResult();

            Assert.AreEqual<string>("Ok", result.Code);
            Assert.IsTrue(result.Matchings.Length > 0);
            Assert.IsTrue(result.Matchings[0].Legs.Length > 0);
            Assert.IsNotNull(result.Matchings[0].Confidence);
        }

        [TestMethod]
        public void Nearest_Response()
        {
            var locToSnap = new Location(52.4224m, 13.333086m);
            
            
            var result = osrm.Nearest(locToSnap).GetAwaiter().GetResult();

            Assert.AreEqual<string>("Ok", result.Code);
            Assert.IsNotNull(result.Waypoints);
            Assert.AreEqual(1, result.Waypoints.Length);
            Assert.IsTrue(result.Waypoints[0].Distance > 0);
            
            // double snapping should be idempotent
            var result2 = osrm.Nearest(result.Waypoints[0].Location).GetAwaiter().GetResult();
            
            Assert.AreEqual(OsrmCode.Ok, result2.Code);
            Assert.IsNotNull(result2.Waypoints);
            Assert.AreEqual(1, result2.Waypoints.Length);
            
            Assert.AreEqual(result.Waypoints[0].Location.Latitude, result2.Waypoints[0].Location.Latitude);
            Assert.AreEqual(result.Waypoints[0].Location.Longitude, result2.Waypoints[0].Location.Longitude);
            Assert.AreEqual(0, result2.Waypoints[0].Distance);
        }

        [TestMethod]
        public void Trip_Response()
        {
            var locations = new Location[] {
                new Location(52.503033m, 13.420526m),
                new Location(52.516582m, 13.429290m),
            };

            var result =  osrm.Trip(locations).GetAwaiter().GetResult();

            Assert.AreEqual<string>("Ok", result.Code);
            Assert.AreEqual<int>(1, result.Trips.Length);
            Assert.IsTrue(result.Trips[0].Legs.Length > 0);
        }
    }
}