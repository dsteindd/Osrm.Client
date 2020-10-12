using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{

    public class RouteStep
    {
        [JsonPropertyName("distance")]
        public decimal Distance { get; set; }

        [JsonPropertyName("duration")]
        public decimal Duration { get; set; }

        [JsonPropertyName("geometry")]
        public string GeometryStr { get; set; }

        public Location[] Geometry
        {
            get
            {
                if (string.IsNullOrEmpty(GeometryStr))
                {
                    return new Location[0];
                }

                return OsrmPolylineConverter.Decode(GeometryStr, 1E5m)
                    .ToArray();
            }
        }

        [JsonPropertyName("maneuver")]
        public StepManeuver Maneuver { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}