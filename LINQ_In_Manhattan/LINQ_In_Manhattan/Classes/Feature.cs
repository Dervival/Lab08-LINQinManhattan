using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_In_Manhattan.Classes
{
    public class Feature
    {
        public string Type { get; set; }
        public Geometry Geo { get; set; }
        public Feature Feat { get; set; }
        public Properties Prop {get; set; }
    }
}
