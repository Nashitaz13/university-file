using GeoCoordinatePortable;

namespace WorkAnywhereAPI.Models
{
    public class GeoPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public GeoCoordinate ToGeoCoordinate() => new GeoCoordinate(this.Latitude, this.Longitude);

    }
}
