using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LINQ_In_Manhattan.Classes
{
    public class SerializedJSON : IEnumerable<Feature>
    {
        public string JsonType { get; set; }
        public List<Feature> Features { get; set; }

        public SerializedJSON(string jsonType, List<Feature> features)
        {
            JsonType = jsonType;
            Features = features;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Feature> GetEnumerator()
        {
            for (int i = 0; i < Features.Count; i++)
            {
                yield return Features[i];
            }
        }
    }
}
