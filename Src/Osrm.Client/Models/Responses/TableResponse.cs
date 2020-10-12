using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Osrm.Client.Models.Responses
{

    public class TableResponse : BaseResponse
    {
        /// <summary>
        /// array of arrays that stores the matrix in row-major order. durations[i][j] gives the travel time from the i-th waypoint to the j-th waypoint. Values are given in seconds.
        /// </summary>
        [JsonPropertyName("durations")]
        public decimal[][] Durations { get; set; }
        
        /// <summary>
        /// array of arrays that stores the matrix in row-major order. distances[i][j] gives the distance from the i-th waypoint
        /// to the j-th waypoint. Values are given in meters.
        /// </summary>
        [JsonPropertyName("distances")]
        public decimal[][] Distances { get; set; }

        /// <summary>
        /// array of Waypoint objects describing all sources in order
        /// </summary>
        [JsonPropertyName("sources")]
        public Waypoint[] Sources { get; set; }

        /// <summary>
        /// array of Waypoint objects describing all destinations in order
        /// </summary>
        [JsonPropertyName("destinations")]
        public Waypoint[] Destinations { get; set; }
    }
}