using Microsoft.VisualStudio.TestTools.UnitTesting;
using Osrm.Client.Models;
using Osrm.Client.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Osrm.Client.Tests
{
    [TestClass]
    public class RequestUrlsTests
    {
        private readonly Location[] locations = new Location[] {
                new Location(52.503033m, 13.420526m),
                new Location(52.516582m, 13.42929m),
            };

        private readonly Location[] matchLocations = new Location[] {
                new Location(52.542648m, 13.393252m),
                new Location(52.543079m, 13.394780m),
                new Location(52.542107m, 13.397389m)
            };

        private string[] ParamValues(List<Tuple<string, string>> urlParams, string paramKey)
        {
            return urlParams.Where(p => p.Item1 == paramKey).Select(p => p.Item2).ToArray();
        }

        [TestMethod]
        public void RouteRequest_Url()
        {
            var r = new RouteRequest
            {
                Coordinates = locations
            };

            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.420526,52.503033"));
            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.429290,52.516582"));

            // Default values are not sent
            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "alternatives").Length);
            //Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "alternatives")[0]);

            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "steps").Length);
            //Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "steps")[0]);

            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "geometries").Length);
            //Assert.AreEqual<string>("polyline", ParamValues(r.UrlParams, "geometries")[0]);

            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "overview").Length);
            //Assert.AreEqual<string>("simplified", ParamValues(r.UrlParams, "overview")[0]);

            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "continue_straight").Length);
            //Assert.AreEqual<string>("default", ParamValues(r.UrlParams, "continue_straight")[0]);
        }

        [TestMethod]
        public void TableRequest_Url()
        {
            var r = new TableRequest
            {
                Coordinates = locations
            };

            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.420526,52.503033"));
            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.429290,52.516582"));

            r.Sources = new uint[1] { 0 };
            var srcParams = ParamValues(r.UrlParams, "sources");
            Assert.AreEqual<int>(1, srcParams.Length);
            Assert.IsTrue(srcParams.Contains("0"));

            r.Destinations = new uint[1] { 1 };
            var dstParams = ParamValues(r.UrlParams, "destinations");
            Assert.AreEqual<int>(1, dstParams.Length);
            Assert.IsTrue(dstParams.Contains("1"));
        }

        [TestMethod]
        public void MatchRequest_Url()
        {
            var r = new MatchRequest
            {
                Coordinates = matchLocations, 
                Timestamps = new int[] { 1424684612, 1424684616, 142468462 }
            };

            // Default values are not sent
            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "steps").Length);
            //Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "steps")[0]);

            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "geometries").Length);
            //Assert.AreEqual<string>("polyline", ParamValues(r.UrlParams, "geometries")[0]);

            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "overview").Length);
            //Assert.AreEqual<string>("simplified", ParamValues(r.UrlParams, "overview")[0]);

            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.393252,52.542648"));
            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.394780,52.543079"));
            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.397389,52.542107"));

            var tParams = ParamValues(r.UrlParams, "timestamps");
            Assert.AreEqual<int>(1, tParams.Length);
            Assert.IsTrue(tParams[0].Contains("1424684612"));
            Assert.IsTrue(tParams[0].Contains("1424684616"));
            Assert.IsTrue(tParams[0].Contains("142468462"));
        }

        [TestMethod]
        public void NearestRequest_Url()
        {
            var r = new NearestRequest()
            {
                Coordinates = new Location[] { new Location(52.4224m, 13.333086m) }
            };

            // Default values are not sent
            //var locParams = ParamValues(r.UrlParams, "number");
            //Assert.AreEqual<int>(1, locParams.Length);
            //Assert.AreEqual<string>("1", locParams[0]);

            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.333086,52.4224"));
        }


        [TestMethod]
        public void TripRequest_Url()
        {
            var r = new TripRequest
            {
                Coordinates = locations
            };

            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.420526,52.503033"));
            Assert.IsTrue(r.CoordinatesUrlPart.Contains("13.429290,52.516582"));

            // Default values are not sent
            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "steps").Length);
            //Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "steps")[0]);

            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "annotate").Length);
            //Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "annotate")[0]);

            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "geometries").Length);
            //Assert.AreEqual<string>("polyline", ParamValues(r.UrlParams, "geometries")[0]);

            //Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "overview").Length);
            //Assert.AreEqual<string>("simplified", ParamValues(r.UrlParams, "overview")[0]);
        }
    }
}