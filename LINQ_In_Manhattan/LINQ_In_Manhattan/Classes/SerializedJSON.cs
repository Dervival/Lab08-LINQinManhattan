using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_In_Manhattan.Classes
{
    public class SerializedJSON
    {
        public string JsonType { get; set; }
        public List<Feature> Features { get; set; }

        public SerializedJSON(string jsonType, List<Feature> features)
        {
            Console.WriteLine("In SerializedJSON constructor");
            Console.WriteLine("jsonType is " + jsonType);
            JsonType = jsonType;
            Features = features;
        }
    }
}
