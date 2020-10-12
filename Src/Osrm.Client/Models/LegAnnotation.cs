using System.Text.Json.Serialization;

namespace Osrm.Client.Models
{
    public class LegAnnotation
    {
        [JsonPropertyName("distance")]
        public decimal[] Distance { get; set; }
        
        [JsonPropertyName("duration")]
        public decimal[] Duration { get; set; }
        
        [JsonPropertyName("speed")]
        public decimal[] Speed { get; set; }
    }
}