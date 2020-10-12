using Osrm.Client.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Osrm.Client.Models.Requests;

namespace Osrm.Client.Demo
{
    class Program
    {
        private static string OsrmUrl = "http://router.project-osrm.org";

        private static void Main(string[] args)
        {
            using HttpClient client = new HttpClient();

            var osrm5x = new Osrm5x(client, OsrmUrl);
            Route5x(osrm5x).GetAwaiter().GetResult();
            Nearest5x(osrm5x).GetAwaiter().GetResult();
            Table5x(osrm5x).GetAwaiter().GetResult();
            Match5x(osrm5x).GetAwaiter().GetResult();
            Trip5x(osrm5x).GetAwaiter().GetResult();
        }

        private static async Task Route5x(Osrm5x osrm)
        {
            var locations = new Location[] {
                new Location(52.503033m, 13.420526m),
                new Location(52.516582m, 13.429290m),
            };

            var result = await osrm.Route(locations);

            var result2 = await osrm.Route(new RouteRequest()
            {
                Coordinates = locations,
                Steps = true
            });
            var result3 = await osrm.Route(new RouteRequest()
            {
                Coordinates = locations,
                SendCoordinatesAsPolyline = true
            });

            var instructions3 = result2.Routes[0].Legs[0].Steps;
        }

        private static async Task Nearest5x(Osrm5x osrm)
        {
            var result = await osrm.Nearest(new Location(52.4224m, 13.333086m));
        }

        private static async Task Table5x(Osrm5x osrm)
        {
            var locations = new Location[] {
                new Location(52.517037m, 13.388860m),
                new Location(52.529407m, 13.397634m),
                new Location(52.523219m, 13.428555m)
            };

            //Returns a 3x3 matrix:
            var result = await osrm.Table(locations);

            //Returns a 1x3 matrix:
            var result2 = await osrm.Table(new TableRequest()
            {
                Coordinates = locations,
                Sources = new uint[] { 0 }
                //Sources = src,
                //DestinationLocations = dst
            });

            //Returns a asymmetric 3x2 matrix with from the polyline encoded locations qikdcB}~dpXkkHz:
            var result3 = await osrm.Table(new TableRequest()
            {
                Coordinates = locations,
                SendCoordinatesAsPolyline = true,
                Sources = new uint[] { 0, 1 },
                Destinations = new uint[] { 1, 2 }
                //Sources = src,
                //DestinationLocations = dst
            });
        }

        private static async Task Match5x(Osrm5x osrm)
        {
            var locations = new Location[] {
                new Location(52.517037m, 13.388860m),
                new Location(52.529407m, 13.397634m),
                new Location(52.523219m, 13.428555m)
            };

            var request = new MatchRequest()
            {
                Coordinates = locations
            };

            var result = await osrm.Match(request);
        }

        private async static Task Trip5x(Osrm5x osrm)
        {
            var locations = new Location[] {
                new Location(52.503033m, 13.420526m),
                new Location(52.516582m, 13.429290m),
            };

            var result = await osrm.Trip(locations);
        }
    }
}
