using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_In_Manhattan.Classes
{
    public class Coords
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Coords(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
