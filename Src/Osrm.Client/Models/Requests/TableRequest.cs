using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models.Requests
{
    public class TableRequest : BaseRequest
    {
        public TableRequest()
        {
            Sources = new uint[0];
            Destinations = new uint[0];
            Annotations = new string[0];
        }

        /// <summary>
        /// Use location with given index as source.
        /// {index};{index}[;{index} ...] or all (default)
        /// </summary>
        public uint[] Sources { get; set; }

        /// <summary>
        /// Use location with given index as destination.
        /// {index};{index}[;{index} ...] or all (default)
        /// </summary>
        public uint[] Destinations { get; set; }
        
        public string[] Annotations { get; set; }

        public override List<Tuple<string, string>> UrlParams
        {
            get
            {
                var urlParams = new List<Tuple<string, string>>(BaseUrlParams);

                urlParams
                    .AddParams("sources", Sources.Select(x => x.ToString()).ToArray())
                    .AddParams("destinations", Destinations.Select(x => x.ToString()).ToArray())
                    .AddStringParameter("annotations", string.Join(",", Annotations),
                        () => Annotations.Length != 0);

                return urlParams;
            }
        }
    }

    public static class TableRequestAnnotation
    {
        public static string[] OnlyDistances = new[] {"distance"};
        // is the default
        public static string[] OnlyDurations = new string[0];
        public static string[] DistancesAndDurations = new []{"distance", "duration"};
    }
}