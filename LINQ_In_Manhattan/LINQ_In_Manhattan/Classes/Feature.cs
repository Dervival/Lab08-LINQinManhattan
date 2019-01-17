using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_In_Manhattan.Classes
{
    public class Feature
    {
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Property {get; set; }

        public Feature(string type, Geometry geo, Properties prop)
        {
            Type = type;
            Geometry = geo;
            Property = prop;
        }
    }
}
