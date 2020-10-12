using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    public class Route
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

                return OsrmPolylineConverter.Decode(GeometryStr, 1E6m)
                    .ToArray();
            }
        }

        [JsonPropertyName("legs")]
        public RouteLeg[] Legs { get; set; }

        /// <summary>
        /// Match. Confidence of the matching. float value between 0 and 1. 1 is very confident that the matching is correct.
        /// </summary>
        [JsonPropertyName("confidence")]
        public float? Confidence { get; set; }
    }
}