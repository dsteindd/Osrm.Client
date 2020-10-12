using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{

    public class RouteLeg
    {
        [JsonPropertyName("distance")]
        public decimal Distance { get; set; }

        [JsonPropertyName("duration")]
        public decimal Duration { get; set; }

        [JsonPropertyName("steps")]
        public RouteStep[] Steps { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    
        [JsonPropertyName("weight")]
        public decimal Weight { get; set; }
        
        [JsonPropertyName("annotation")]
        public LegAnnotation LegAnnotation { get; set; }
    }
}