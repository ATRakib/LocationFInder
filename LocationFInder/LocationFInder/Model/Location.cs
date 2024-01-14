using System;

namespace LocationFInder.Model
{
    public class Location
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
