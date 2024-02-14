using System;
using System.Collections.Generic;
using System.Text;

namespace LocationFInderApp.Models
{
    public class LocationView
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Timestamp { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class LocationModel
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
