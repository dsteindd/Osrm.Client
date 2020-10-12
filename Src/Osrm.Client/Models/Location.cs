using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    public class Location //: System.Object
    {
        public Location()
        {
        }

        public Location(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Location p))
            {
                return false;
            }

            return (Latitude == p.Latitude) && (Longitude == p.Longitude);
        }

        public bool Equals(Location p)
        {
            if (p is null)
            {
                return false;
            }

            return (Latitude == p.Latitude) && (Longitude == p.Longitude);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Latitude, Longitude);
        }

        public static bool operator ==(Location a, Location b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if ((a is null) || (b is null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Latitude == b.Latitude && a.Longitude == b.Longitude;
        }

        public static bool operator !=(Location a, Location b)
        {
            return !(a == b);
        }
    }
}